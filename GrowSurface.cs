/*
 ***  Various proedures of deposition:
 
 Eden Model:    in this model a perimeter site is choosen randomly and occuiped.
 Randomly  :    in this model a column is choosen randomly and a particle is deposited on top of current column.
 Ballistic :    in this model a column choosen randomly and a particle is assumd to fall verticaly until it reaches the first perimeter
                site that is nearest neighbour of a site that already is part of the surface.
 DLA       :    in this model a particle move randomly until reached to a perimetr site.
 
 RDSR:    (random deposition surface relaxation) afther releaseing a sand then, relax to neighbour sites
 * 
 * We use cyclic in x direction.
 * h_x is the maaximum distance of any perimeter site in column x
 
*/
using System;

namespace GrowingSurfaces
{
    public enum Deposition { EdenModel, Random, Ballistic, DLA ,RSOS, SOS, RDSR, WV, DST};
    public enum SubstrateType { Flat, Wegded};
    public struct Location
    {
        public int x, y;
        public Location(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class GrowSurface
    {
        public int L, H;        // L is the width of substarate. H is the maximul lenght of Box
        public byte[,] site;     // site[i, j] = 2  perimeter site,  site[i, j] = 1 is occuiped site,  site[i, j] = 0 is empty space 
        public int n_perim;     // number of perimeter sites
        public Deposition method;
        public bool isReachedTop; // represnt that particles have reached th top of our array.
        public int[] h_x;           //is the maaximum distance of any perimeter site in column x
        private byte[] bonds;       // just for Wolf Vilian method

        Location[] permiters;
        Random rand = new Random();
        readonly static int[] nX = { 1, 0, -1, 0 }; // direction
        readonly static int[] nY = { 0, 1, 0, -1 };
        public int h_max;
        public int nAddedParticles  = 0;

        public double p_p = 1 / 2.0;        // for SOS model
        public double p_m = 1 / 2.0;

        public SubstrateType subType = SubstrateType.Flat;

        public GrowSurface(int L, int H, Deposition method, SubstrateType subType)
        {
            this.L = L;
            this.H = H;
            this.method = method;
            this.subType = subType;
            Initialze();
        }
        void Initialze()
        {
            isReachedTop = false;
            site = new byte[L, H];
            h_x = new int[L];
            if (method == Deposition.EdenModel)
                permiters = new Location[2 * L * H / 3];
            else if (method == Deposition.WV || method == Deposition.DST)
            {
                bonds = new byte[L];
                for (int i = 0; i < L; i++)
                    bonds[i] = 1;
            }
            
            // we first create substrate
            for (int i = 0; i < L; i++)
            {
                switch (subType)
                {
                    case SubstrateType.Flat :
                        h_x[i] = 0;
                        break;
                    case SubstrateType.Wegded:
                        h_x[i] = Math.Abs(i - L / 2);
                        break;

                }
                site[i, h_x[i]] = 1; // occuiped site
                site[i, h_x[i]+1] = 2; // perimeter site
                if (permiters != null)
                    permiters[i] = new Location(i, 1);
            }
            if (subType == SubstrateType.Flat) h_max = 0;
            else h_max = L / 2;
                n_perim = L;
        }


        /// <summary>
        /// Deposite one partcile on surface.
        /// </summary>
        public void Deposite(ref int xO, ref int yO)
        {
            int x = 0, y = 0, x1, x2, i_perim;
            switch(method)
            {
                case Deposition.EdenModel:
                    i_perim = rand.Next(n_perim);
                    x = permiters[i_perim].x;
                    y = permiters[i_perim].y;
                    permiters[i_perim] = permiters[n_perim - 1];
                    n_perim--;
                    if (y > h_x[x]) h_x[x] = y;
                    break;
                case Deposition.Random:
                    x = rand.Next(L);
                    y = ++h_x[x];
                    break;
                case Deposition.Ballistic:
                    x = rand.Next(L);
                    MoveParticleBallistic(x, ref y);
                    h_x[x] = y;
                    break;
                case Deposition.DLA:
                    MoveParticleDLA(ref x, ref y);
                    if (y > h_x[x]) h_x[x] = y;
                    break;
                case Deposition.RSOS:
                    MoveParticleRSOS(ref x, ref y);
                    h_x[x] = y;
                    break;

                case Deposition.RDSR:
                    x = rand.Next(L);
                    // old def
                    x1 = x == 0 ? L - 1 : x - 1;
                    x2 = x == L - 1 ? 0 : x + 1;
                    x = FindMinh_x(x1, x, x2);
                    y = ++h_x[x];                    
                    /*while (true)
                    {
                        int x1 = x == 0 ? L - 1 : x - 1;
                        int x2 = x == L - 1 ? 0 : x + 1;
                        int xf = FindMinh_x(x1, x, x2);
                        if (xf == x)
                        {
                            x = xf;
                            y = ++h_x[x];
                            break;
                        }
                        x = xf;
                    }*/
                    break;

                case Deposition.WV:
                    {
                        x = rand.Next(L);
                        x1 = x == 0 ? L - 1 : x - 1;
                        x2 = x == L - 1 ? 0 : x + 1;
                        byte b_max = bonds[x];
                        if (bonds[x1] > bonds[x]) b_max = bonds[x1];
                        if (bonds[x2] > bonds[x]) b_max = bonds[x2];

                        if (b_max == bonds[x])
                        {
                            y = ++h_x[x];
                            ChangeBonds(x, x1, x2);
                            break;                           
                        }

                        int[] X = new int[2];
                        int n = 0;
                        if (bonds[x1] == b_max)
                            X[n++] = x1;

                        if (bonds[x2] == b_max)
                            X[n++] = x2;

                        int ir = (n == 1) ? 0 : rand.Next(n);
                        int xt = X[ir];
                        y = ++h_x[xt];
                        int xt1 = xt > 0 ? xt - 1 : L - 1;
                        int xt2 = xt < L - 1 ? xt + 1 : 0;
                        ChangeBonds(xt, xt1, xt2);
                        
                        break;
                    }

                case Deposition.DST:
                    {
                        x = rand.Next(L);
                        x1 = x == 0 ? L - 1 : x - 1;
                        x2 = x == L - 1 ? 0 : x + 1;

                        if (bonds[x] > 1)  // if deposited site is kink site
                        {
                            y = ++h_x[x];
                            ChangeBonds(x, x1, x2);
                            break;
                        }

                        // Now neighbours ...
                        int[] X = new int[2];
                        int n = 0;
                        if (bonds[x1] > 1) X[n++] = x1;
                        if (bonds[x2] > 1) X[n++] = x2;

                        if (n == 0)
                        {
                            y = ++h_x[x];
                            ChangeBonds(x, x1, x2);
                            break;
                        }

                        int ir = (n == 1) ? 0 : rand.Next(n);
                        int xt = X[ir];
                        y = ++h_x[xt];
                        int xt1 = xt > 0 ? xt - 1 : L - 1;
                        int xt2 = xt < L - 1 ? xt + 1 : 0;
                        ChangeBonds(xt, xt1, xt2);

                        break;
                    }
            }
              

            if (h_x[x] > h_max) h_max = h_x[x];
            
            

            site[x, y] = 1;
            if (method != Deposition.Random)
                NearestPerimeters(x, y);
            nAddedParticles++;
            xO = x;
            yO = y;
        }

        void ChangeBonds(int x, int x1, int x2)
        {
            int dh1 = h_x[x] - h_x[x1];
            if (dh1 == 1)       bonds[x1]++;
            else if (dh1 == 0)  bonds[x]--;

            int dh2 = h_x[x] - h_x[x2];
            if (dh2 == 1)       bonds[x2]++;
            else if (dh2 == 0)  bonds[x]--;
        }

        void NearestPerimeters(int x, int y)
        {
            int xNew, yNew;
            const int top = 4;
            //if (method == Deposition.Ballistic) top = 3;
            for (int i = 0; i < top; i++)
            {
                xNew = PBC(x + nX[i]);
                yNew = y + nY[i];

                if (yNew >= H)  //  then we stop all calculations
                {
                    isReachedTop = true;
                    return;
                }
                if (site[xNew, yNew] == 0)
                {
                    //if (yNew > h_x[xNew]) h_x[xNew] = yNew;
                    //if (yNew > h_max) h_max = yNew;
                    site[xNew, yNew] = 2;
                    if (permiters != null)
                    {
                        permiters[n_perim] = new Location(xNew, yNew);
                        n_perim++;
                    }
                }
            }
        }

        private int FindMinh_x(int x1, int x, int x2)
        {
            int minh = h_x[x];
            if (h_x[x1] < minh)                minh = h_x[x1]; 
            if (h_x[x2] < minh)                minh = h_x[x2];


            if (minh == h_x[x])
                return x;
            else if (h_x[x1] == h_x[x2])
            {
                if (rand.NextDouble() < 0.5)
                    return x1;
                else
                    return x2;
            }
            else if (minh == h_x[x1])
                return x1;
            else
                return x2;

        }

        int PBC(int i)
        {
            if (i >= L)
                return 0;
            else if (i < 0)
                return L - 1;
            else return i;
        }

        void MoveParticleBallistic(int x, ref int y)
        {
            y = Max(h_x[x] + 1, h_x[PBC(x - 1)], h_x[PBC(x + 1)]);
            
        }
        void MoveParticleDLA(ref int x, ref int y)
        {
            bool isOnPeriemetr = false;
            double r;
            int stepY = 1;

            do
            {
                x = rand.Next(L);
                y = h_max + 3;
                do
                {
                    stepY = (y > h_max + 3) ? 2 : 1;
                    r = rand.NextDouble();
                    if (r < 0.25) x += 1;
                    else if (r < 0.5) x -= 1;
                    else if (r < 0.75) y += stepY;
                    else y -= stepY;

                    x = PBC(x);
                    if (site[x, y] == 2)
                    {
                        isOnPeriemetr = true;
                        break;
                    }

                } while (y < 2 * h_max + 6);
            } while (!isOnPeriemetr);

        }

        void MoveParticleRSOS(ref int x, ref int y)
        {
        loop1:
            x = rand.Next(L);
            int x1 = PBC(x - 1);
            int x2 = PBC(x + 1);
            if (h_x[x2] >= h_x[x] && h_x[x1] >= h_x[x])
                y = ++h_x[x];

            else
                goto loop1;
        }


        void MoveParticleSOS(ref int x, ref int y)
        {

        }


      

        public void Find_H_Distribution(out int[] distrbution_h )
        {
            int h_min = int.MaxValue;
            for (int i = 0; i < L; i++)
                if (h_x[i] < h_min) h_min = h_x[i];

            int lenght = h_max - h_min + 1;
            distrbution_h = new int[lenght];
            for (int i = 0; i < L; i++)
                distrbution_h[h_x[i] - h_min]++;
        }

        public void FindSurfaceWidth(out double w, out double h_ave)
        {
            h_ave = 0;
            int i;
            for (i = 0; i < L; i++)
                h_ave += h_x[i];
            h_ave /= L;

            w = 0;
            for ( i = 0; i < L; i++)
            {
                double dh = h_x[i] - h_ave;
                w += dh * dh;
            }
            w /= L;
           
        }


        

        int Max(int a, int b, int c)
        {
            int result = a;
            if (b > result) result = b;
            if (c > result) result = c;
            return result;
        }



    }
}
