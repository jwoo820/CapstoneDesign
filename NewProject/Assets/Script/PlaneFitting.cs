using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneFitting : MonoBehaviour
{
    //BOOL RANSAC_LineFitting(POINT* Q, int N


    //                                       double dist_th/*=10*/,
    //                                       int max_iter    /*=100*/,
    //                                       int num_th     /*=20*/,
    //                                       double line[4])
    //{
    //    int iter = 0;
    //    POINT* P = new POINT[N];
    //    double* weight = new double[N];
    //    srand(unsigned(time(0)));
    //    while (iter < max_iter)
    //    {
    //        int i0 = (rand() % N), i1;
    //        P[0] = Q[i0];
    //        do
    //        {
    //            i1 = rand() % N;
    //        } while (i1 == i0);
    //        P[1] = Q[i1];
    //        //degeneracy_check;
    //        if (P[1] == P[0]) continue;

    //        //line eq of two points;
    //        line[0] = P[1].x - P[0].x;
    //        line[1] = P[1].y - P[0].y;
    //        line[2] = P[0].x;
    //        line[3] = P[0].y;

    //        //collect maybeinliers;
    //        int n = 2;
    //        for (int j = 0; j < N; j++)
    //        {
    //            if (j == i0 || j == i1) continue;
    //            double dist = dist2Line(line, Q[j]);
    //            if (dist <= dist_th)
    //            {
    //                P[n++] = Q[j];
    //            }
    //        }
    //        if (n >= num_th)
    //        {
    //            for (int j = 0; j < n; j++) weight[j] = 1.;
    //            LineFit_PCA(P, n, weight, line);
    //            break;
    //        }
    //        iter++;
    //    }
    //    delete[] P;
    //    delete[] weight;
    //    return (iter != max_iter);
    //}

}

