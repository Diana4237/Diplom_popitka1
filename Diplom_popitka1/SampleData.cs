using Diplom_popitka1.Models;
using System.Numerics;

namespace Diplom_popitka1
{
    public class SampleData
    {
        public static void Initialize(diplom_popitca1Context context, IWebHostEnvironment env)
        {
            //
            byte[] a = File.ReadAllBytes(@"wwwroot\images\places\1.JPG");
            byte[] b = File.ReadAllBytes(@"wwwroot\images\places\2.JPG");
            byte[] c = File.ReadAllBytes(@"wwwroot\images\places\3.JPG");
            byte[] d = File.ReadAllBytes(@"wwwroot\images\places\4.JPG");
            byte[] e = File.ReadAllBytes(@"wwwroot\images\places\5.JPG");
            byte[] f = File.ReadAllBytes(@"wwwroot\images\places\6.JPG");
            byte[] g = File.ReadAllBytes(@"wwwroot\images\places\7.JPG");
            byte[] h = File.ReadAllBytes(@"wwwroot\images\places\8.JPG");
            byte[] i = File.ReadAllBytes(@"wwwroot\images\places\9.JPG");
            byte[] j = File.ReadAllBytes(@"wwwroot\images\places\10.JPG");
            byte[] k = File.ReadAllBytes(@"wwwroot\images\places\11.JPG");
            byte[] l = File.ReadAllBytes(@"wwwroot\images\places\12.JPG");
            byte[] m = File.ReadAllBytes(@"wwwroot\images\places\13.jpg");
            byte[] n = File.ReadAllBytes(@"wwwroot\images\places\14.jpg");
            byte[] o = File.ReadAllBytes(@"wwwroot\images\places\15.JPG");
            byte[] p = File.ReadAllBytes(@"wwwroot\images\places\16.JPG");
            byte[] q = File.ReadAllBytes(@"wwwroot\images\places\17.JPG");
            byte[] r = File.ReadAllBytes(@"wwwroot\images\places\18.JPG");
            byte[] s = File.ReadAllBytes(@"wwwroot\images\places\19.JPG");
            byte[] t = File.ReadAllBytes(@"wwwroot\images\places\20.JPG");
            byte[] u = File.ReadAllBytes(@"wwwroot\images\places\21.JPG");
            byte[] v = File.ReadAllBytes(@"wwwroot\images\places\22.JPG");
            byte[] w = File.ReadAllBytes(@"wwwroot\images\places\23.JPG");
            byte[] x = File.ReadAllBytes(@"wwwroot\images\places\24.JPG");
            //byte[] y = File.ReadAllBytes(@"wwwroot\images\places\16.JPG");
            //byte[] z = File.ReadAllBytes(@"wwwroot\images\places\16.JPG");
            //if (!context.Places.Any())
            //{
            //    context.Places.AddRange(
            //        new Places
            //        {
            //            Name = "",
            //            Photo = a
            //        },
            //        new Places
            //        {
            //            Name = "",
            //            Photo = b
            //        },
            //        new Places
            //        {
            //            Name = "",
            //            Photo = c
            //        },
            //        new Places
            //        {
            //            Name = "",
            //            Photo = d
            //        },
            //        new Places
            //        {
            //            Name = "",
            //            Photo = e
            //        },
            //        new Places
            //        {
            //            Name = "",
            //            Photo = f
            //        },

            //        new Places
            //        {
            //            Name = "",
            //            Photo = g
            //        },
            //        new Places
            //        {
            //            Name = "",
            //            Photo = h
            //        },
            //        new Places
            //        {
            //            Name = "",
            //            Photo = i
            //        },
            //        new Places
            //        {
            //            Name = "",
            //            Photo = j
            //        },
            //        new Places
            //        {
            //            Name = "",
            //            Photo = k
            //        },
            //          new Places
            //          {
            //              Name = "",
            //              Photo = l
            //          },
            //        new Places
            //        {
            //            Name = "",
            //            Photo = m
            //        },
            //        new Places
            //        {
            //            Name = "",
            //            Photo = n
            //        },
            //        new Places
            //        {
            //            Name = "",
            //            Photo = o
            //        },

            //        new Places
            //        {
            //            Name = "",
            //            Photo = p
            //        },
            //        new Places
            //        {
            //            Name = "",
            //            Photo = q
            //        },
            //        new Places
            //        {
            //            Name = "",
            //            Photo = r
            //        },
            //        new Places
            //        {
            //            Name = "",
            //            Photo = s
            //        },
            //        new Places
            //        {
            //            Name = "",
            //            Photo = t
            //        },
            //        new Places
            //        {
            //            Name = "",
            //            Photo = u
            //        },
            //        new Places
            //        {
            //            Name = "",
            //            Photo = v
            //        },
            //        new Places
            //        {
            //            Name = "",
            //            Photo = w
            //        },
            //        new Places
            //        {
            //            Name = "",
            //            Photo = x
            //        }
            //        );
            //    context.SaveChanges();


                //if (!context.Roles.Any())
                //{
                //    Roles doctor = new Roles
                //    {
                //        Name = "Client"

                //    };
                //    context.Roles.Add(doctor);
                //    context.SaveChanges();
                //    Roles doctor2 = new Roles
                //    {
                //        Name = "Mechanic"

                //    };
                //    context.Roles.Add(doctor2);
                //    context.SaveChanges();
                //}
            //}
        }
    }
}
