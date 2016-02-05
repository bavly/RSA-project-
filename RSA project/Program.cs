using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ConsoleApplication2;

namespace ConsoleApplication2
{
    public class BigNum
    {
        bool flag = false;
        public BigNum()
        {
            flag = false;
        }
        public string add(string num1, string num2)
        {
            int min, max;
            string negativ = num1.Substring(0, 1);
            if (negativ == "-")
                num1 = num1.Substring(1, num1.Length - 1);
            //Console.Write(num1);
            if (num1.Length < num2.Length)
            {
                max = num2.Length;
                min = num1.Length;
            }
            else
            {
                min = num2.Length;
                max = num1.Length;
            }
            int[] n1 = new int[max];
            int[] n2 = new int[max];
            for (int i = 0; i < num1.Length; i++)
            {
                string index = num1.Substring(num1.Length - 1 - i, 1);
                if (index != "\0")
                    n1[i] = Convert.ToInt32(index);
            }
            if (num1.Length < max)
                for (int i = num1.Length; i < max; i++)
                {
                    n1[i] = 0;
                }
            for (int i = 0; i < num2.Length; i++)
            {
                string index2 = num2.Substring(num2.Length - 1 - i, 1);
                if (index2 != "\0")
                    n2[i] = Convert.ToInt32(index2);
            }
            if (num2.Length < max)
                for (int i = num2.Length; i < max; i++)
                {
                    n2[i] = 0;
                }
            int carry = 0;
            int[] sum = new int[max + 1];
            int[] nsum = new int[max + 1];
            for (int k = 0; k < max; k++)
            {
                sum[k] = (n1[k] + n2[k] + carry) % 10;
                if (n1[k] + n2[k] + carry >= 10)
                    carry = 1;
                else
                    carry = 0;
            }
            sum[max] = carry;
            for (int j = max; j >= 0; j--)
            {
                nsum[max - j] = sum[j];
            }
            int ji;
            for (ji = 0; ji <= max; ji++)
                if (nsum[ji] != 0)
                    break;
            char[] temp = new char[max - ji + 1];
            for (int i = ji, index = 0; i <= max; i++, index++)
            {
                temp[index] = (char)(nsum[i] + '0');
            }
            string result = new string(temp);
            if (result == "" || result == "0")
                return "0";
            return result;
        }
        public string sub(string num1, string num2)
        {
            int min, max;
            if (num1.Length < num2.Length)
            {
                max = num2.Length;
                min = num1.Length;
            }
            else
            {
                min = num2.Length;
                max = num1.Length;
            }
            int[] n1 = new int[max];
            int[] n2 = new int[max];
            for (int i = 0; i < num1.Length; i++)
            {
                string index = num1.Substring(num1.Length - 1 - i, 1);
                if (index != "\0")
                    n1[i] = Convert.ToInt32(index);
            }
            if (num1.Length < max)
                for (int i = num1.Length; i < max; i++)
                {
                    n1[i] = 0;
                }
            for (int i = 0; i < num2.Length; i++)
            {
                string index2 = num2.Substring(num2.Length - 1 - i, 1);
                if (index2 != "\0")
                    n2[i] = Convert.ToInt32(index2);
            }
            if (num2.Length < max)
                for (int i = num2.Length; i < max; i++)
                {
                    n2[i] = 0;
                }
            //check anhe akbr
            int b = max - 1;
            while (b != -1)
            {
                if (n1[b] == n2[b])
                    b--;
                else if (n1[b] < n2[b])
                {
                    flag = true;
                    return sub(num2, num1);
                }
                else
                    break;
            }
            int carry = 0;
            int[] sum = new int[max];
            for (int k = 0; k < max; k++)
            {
                if (n1[k] - n2[k] - carry < 0)
                {
                    sum[k] = (n1[k] - n2[k] - carry + 10);
                    carry = 1;
                }
                else if (n1[k] - n2[k] - carry >= 0)
                {
                    sum[k] = (n1[k] - n2[k] - carry);
                    carry = 0;
                }
            }
            ;

            if (flag)
            {
                Console.Write('-');
                flag = false;
            }
            int[] nsum = new int[max];
            for (int j = max - 1; j >= 0; j--)
            {
                nsum[max - 1 - j] = sum[j];
            }
            int ji;
            for (ji = 0; ji < max; ji++)
                if (nsum[ji] != 0)
                    break;
            char[] temp = new char[max - ji + 1];
            for (int i = ji, index = 0; i <= max - 1; i++, index++)
            {
                temp[index] = (char)(nsum[i] + '0');
            }
            string result = new string(temp);
            int hj = 0;
            char[] nre = new char[result.Length - 1];
            while (result[hj] != '\0' && hj < result.Length - 1)
            {
                nre[hj] = result[hj];
                hj++;
            }


            string nresult = new string(nre);
            if (nresult == "" || nresult == "0" || nresult == "\0\0")
                return "0";
            return nresult;
        }
        public void Odd_even(string num)
        {
            int k = num[num.Length - 1];
            if (k % 2 == 0)
                Console.WriteLine("This Number is Even ");
            else
                Console.WriteLine("This Number is Odd ");
        }
        public bool isgreater(string num1, string num2)
        {
            int min, max;
            if (num1.Length < num2.Length)
            {
                max = num2.Length;
                min = num1.Length;
            }
            else
            {
                min = num2.Length;
                max = num1.Length;
            }
            int[] n1 = new int[max];
            int[] n2 = new int[max];
            for (int i = 0; i < num1.Length; i++)
            {
                string index = num1.Substring(num1.Length - 1 - i, 1);
                if (index != "\0")
                    n1[i] = Convert.ToInt32(index);
            }
            if (num1.Length < max)
                for (int i = num1.Length; i < max; i++)
                {
                    n1[i] = 0;
                }
            for (int i = 0; i < num2.Length; i++)
            {
                string index2 = num2.Substring(num2.Length - 1 - i, 1);
                if (index2 != "\0")
                    n2[i] = Convert.ToInt32(index2);
            }
            if (num2.Length < max)
                for (int i = num2.Length; i < max; i++)
                {
                    n2[i] = 0;
                }
            //check anhe akbr
            int b = max - 1;
            while (b != -1)
            {
                if (n1[b] == n2[b])
                    b--;
                else if (n1[b] < n2[b])
                {
                    return true;
                }
                else
                    return false;
            }
            return false;
        }
        public Tuple<string, string> divid(string num1, string num2)
        {

            if (isgreater(num1, num2))
                return new Tuple<string, string>("0", num1);
            string B2 = add(num2, num2);
            Tuple<string, string> qr = divid(num1, B2);
            string q = add(qr.Item1, qr.Item1);
            if (isgreater(qr.Item2, num2))
                return new Tuple<string, string>(q, qr.Item2);
            else
                return new Tuple<string, string>(add(q, "1"), sub(qr.Item2, num2));
            //////////////////////////////////////////////////////////////////
        }
        public string Pow(string B, string P, string N)
        {
            if (P == "0")
            {
                string one = "1";
                Tuple<string, string> qrr = divid(one, N);
                return qrr.Item2;
            }
            else if (P == "1")
            {
                Tuple<string, string> qrr = divid(B, N);
                return qrr.Item2;
            }
            Tuple<string, string> qr = divid(P, "2");
            string power = Pow(B, qr.Item1, N);
            if (qr.Item2 == "0") //even case
            {
                Tuple<string, string> qrrr = divid(multiply(power, power), N);
                return qrrr.Item2;
            }
            else //odd case
            {
                Tuple<string, string> qrrr = divid(multiply(B, multiply(power, power)), N);
                return qrrr.Item2;
                // return multiply(B, multiply(power, power));
            }
        }
        public string multiply(string num1, string num2)
        {
            int min, max;
            //1-law el size bta3 num1.length != num2.length yb2a a5lehm zy b3d.. bgeb 
            //el diff mben size bt3hm wa tzwdo esfar le rkm el as3'r .
            //    .msln num1 = 5555 wa num2 = 7 ht5lehm kda num1 = 123 num2 = 007

            if (num1.Length < num2.Length)
            {
                max = num2.Length;
                min = num1.Length;
                int diff = max - min;
                string zeros; zeros = "";
                for (int i = 0; i < diff; i++)
                {
                    zeros += "0";
                }
                num1 = zeros + num1;
            }
            else if (num1.Length > num2.Length)
            {
                min = num2.Length;
                max = num1.Length;
                int diff = max - min;
                string zeros; zeros = "";
                for (int i = 0; i < diff; i++)
                {
                    zeros += "0";
                }
                num2 = zeros + num2;
            }
            if (num1.Length % 2 == 1 && num1.Length != 1)
            {
                num1 = '0' + num1;
                num2 = '0' + num2;
            }

            //2-lazm length bta3 num1, num2 ykon even number.. 
            //    fa b3d ma 5let el sizes zy b3d.. law odd azwd sfr zyada .. 
            //        msln e7na num1 b2a = 123, wa num2 = 007..hzwd sfr zyada fe el awl ..
            //            fa hyb2o kda num1 = 0123 , num2 = 0007. bs btzwd el klam da law el length akbr mn wa7d..
            //            3lshan myb2ash el rkm 3ndk 1 msln wa yfdl yzwd sfr..wa yb2a infinte loop .. 
            //                fa lazm ykon el length odd wa akbr mn 1 .


            /** Maximum of lengths of number **/
            int n = (int)Math.Max(num1.Length, num2.Length);
            /** for small values directly multiply **/
            //            3-el stop condition en enta ht3ml recursion l3'yet ma yb2a el length wa7d ..
            //            fa tdrbhm fe b3d ka integer wa trg3hm ka string. 
            //                fa law num1.length 1 wa ana damn el num1.length = num2.length 
            //            3lshan shrt rkm 1 . fa h3ml drb mn num1[0] wa num[0] wa a3ml return .

            // stop condtion
            if (num1 == "0" || num2 == "0")
            {
                string ol11;
                ol11 = "0";
                return ol11;
            }
            if (num1.Length == 1)
            {
                int x, y;
                x = int.Parse(num1[0].ToString());
                y = int.Parse(num2[0].ToString());
                return ((x * y).ToString());
            }
            int fh = n / 2; // First half of string, floor(n/2)
            int sh = (n - fh); // Second half of string, ceil(n/2)

            // Find the first half and second half of first string.

            string a = num1.Substring(0, fh);
            string b = num1.Substring(fh, sh);

            // Find the first half and second half of second string
            string c = num2.Substring(0, fh);
            string d = num2.Substring(fh, sh);
            string z0 = multiply(a, c);
            string z1 = multiply(b, d);
            string z2 = multiply(add(a, b), add(c, d));
            string last;
            last = add(z0, z1);
            z2 = sub(z2, last);
            //4-a5er 7aga hshel el esfar elzyada ele fe el awl abl m3ml return le result..
            //3lshan my3mlsh return le  rkm be size 3'lt ..
            //msln howa 3ml return le ntegt el ac. kda 070 ..
            //    hy5dha ka size 3..wa da 3'lt lma yege y3ml add fe el a5r 3lshan el mfrod tb2a ac+ 00 msh ac +000 ,, 
            //fa law result[0] == 0 ..h3mlo remove bs lazm ykon el length akbr mn wa7d .. 
            //3lshan my3ml out of range exception ..3lshan law el result = 0.. 
            //    hyshelo wa yb2a el string fady .. wa y3ml acess le reult[0] fa ydrb.

            for (int i = 0; i < num1.Length; i++)
            {
                z0 = z0 + "0";
            }
            for (int i = 0; i < (num1.Length / 2); i++)
            {
                z2 = z2 + "0";
            }
            while (z2[0] == '0' && z2.Length != 1)
            {
                z2 = z2.Remove(0, 1);
            }

            return add(z2, add(z1, z0));
        }
        public string encryption(string m, string e, string n)
        {
            string aout = "that is not available it's not availabe diveded by zero  ";
            if (n == "0")
            {
                return aout;
            }
            string em = Pow(m, e, n);
            //Tuple<string, string> qr = divid(em, n);
            //return qr.Item2;


            return em;
        }
    }
}
class Program
{
    static void Main(string[] args)
    {


        //Sw.WriteLine("hello");       
        // hello will be written in the file           
        FileStream fsr = new FileStream("Delimiter.txt", FileMode.Open, FileAccess.Read);
        // to open the file    
        StreamReader Sr = new StreamReader(fsr);             // to read from the file      

        FileStream Csr = new FileStream("TestRSA.txt", FileMode.Open, FileAccess.Read);
        StreamReader Cr = new StreamReader(Csr);
        //FileStream fs = new FileStream("complete.txt", FileMode.Open, FileAccess.Read);
        //// to open the file    
        //StreamReader Ser = new StreamReader(fs);             // to read from the file      

        BigNum obj = new BigNum();
        while (true)
        {
            FileStream fsw = new FileStream("Rsimple.txt", FileMode.Append, FileAccess.Write);
            // to creat file its name is T               
            string kkk = Sr.ReadLine();
            StreamWriter Sw = new StreamWriter(fsw);
            FileStream Csw = new FileStream("Rcomplete.txt", FileMode.Append, FileAccess.Write);
            // to creat file its name is T               
            string kkkk = Cr.ReadLine();
            StreamWriter Cw = new StreamWriter(Csw);
            // to write in the T file           
            Console.WriteLine("[1] Add Tow Numbers");
            Console.WriteLine("[2] Subtract Tow Numbers");
            Console.WriteLine("[3] divid Tow Numbers");
            Console.WriteLine("[4] multiply Tow Numbers");
            Console.WriteLine("[5] encrpt and decrypt ");
            Console.WriteLine("[6] Enter The Number want to check it: ");
            Console.WriteLine("                 -----------------------------------------------");
            Console.WriteLine("                 -----------------------------------------------");
            Console.Write("#Enter Your choice: ");
            string k = Console.ReadLine();
            Console.WriteLine("                 ");
            if (k == "1" || k == "2" || k == "3" || k == "4" || k == "5" || k == "6")
            {


                if (k == "1")
                {
                    Console.Write("#Enter The First Number: ");
                    string number1 = Console.ReadLine();
                    Console.Write("#Enter The Second Number: ");
                    string number2 = Console.ReadLine();

                    Console.Write("Your Result is :->>     ");
                    Console.Write(obj.add(number1, number2));
                }

                if (k == "2")
                {
                    Console.Write("#Enter The First Number: ");
                    string number1 = Console.ReadLine();
                    Console.Write("#Enter The Second Number: ");
                    string number2 = Console.ReadLine();

                    Console.Write("Your Result is :->>     ");
                    Console.Write(obj.sub(number1, number2));
                }
                if (k == "3")
                {
                    Console.Write("#Enter The First Number: ");
                    string number1 = Console.ReadLine();
                    Console.Write("#Enter The Second Number: ");
                    string number2 = Console.ReadLine();
                    Console.WriteLine("                 ");
                    Tuple<string, string> b = obj.divid(number1, number2);

                    Console.Write("Your Result is :->>     ");
                    Console.WriteLine(b.Item1 + "  " + b.Item2);
                }
                if (k == "4")
                {
                    Console.Write("#Enter The First Number: ");
                    string number1 = Console.ReadLine();
                    Console.Write("#Enter The Second Number: ");
                    string number2 = Console.ReadLine();
                    Console.WriteLine("                 ");

                    Console.Write("Your Result is :->>     ");
                    Console.Write(obj.multiply(number1, number2));
                }


                if (k == "5")
                {
                    //    string line = Sr.ReadLine();
                    //    Console.WriteLine("The line in the file is : " + line);
                    Console.WriteLine("RSA Project:\n[1] Sample test cases\n[2] Complete testing");
                    Console.Write("\nEnter your choice [1-2]: ");
                    char choice = (char)Console.ReadLine()[0];
                    switch (choice)
                    {
                        case '1':
                            while (Sr.Peek() != -1)
                            {
                                Console.Write("#Enter The Number Of Mode : ");
                                string Bb = Sr.ReadLine();
                                Console.WriteLine(Bb);
                                Console.Write("#Enter The Number Of Power : ");
                                string Pb = Sr.ReadLine();
                                Console.WriteLine(Pb);
                                Console.Write("#Enter The Number Of Base : ");
                                string z45 = Sr.ReadLine();
                                Console.WriteLine(z45);
                                string de = Sr.ReadLine();

                                if (de == "1")
                                {
                                    Console.Write("The Result of Encryption Operation is :->>     ");
                                    Console.WriteLine(obj.encryption(z45, Pb, Bb));
                                    string fols = obj.encryption(z45, Pb, Bb);
                                    Sw.WriteLine(fols);

                                }
                                else
                                {
                                    Console.Write("The Result of Decryption Operation is :->>     ");
                                    Console.WriteLine(obj.encryption(z45, Pb, Bb));
                                    string fols = obj.encryption(z45, Pb, Bb);
                                    Sw.WriteLine(fols);

                                }
                                Console.WriteLine("_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
                                Console.WriteLine("  ");
                            }
                            Sw.Close();
                            fsw.Close();


                            Console.WriteLine("  ");
                            Console.Write("Do you want to run Complete Testing now (y/n)? ");
                            Console.WriteLine("  ");
                            choice = (char)Console.Read();
                            if (choice == 'n' || choice == 'N')
                                break;
                            else if (choice == 'y' || choice == 'Y')
                                goto CompleteTest;
                            else
                            {
                                Console.WriteLine("Invalid Choice!");
                                break;
                            }

                        case '2':
                        CompleteTest:
                            Console.WriteLine("Complete Testing is running now...");
                            Console.WriteLine("  ");
                            while (Cr.Peek() != -1)
                            {
                                Console.Write("#Enter The Number Of Mode : ");
                                string Bb = Cr.ReadLine();
                                Console.WriteLine(Bb);
                                Console.Write("#Enter The Number Of Power : ");
                                string Pb = Cr.ReadLine();
                                Console.WriteLine(Pb);
                                Console.Write("#Enter The Number Of Base : ");
                                string z45 = Cr.ReadLine();
                                Console.WriteLine(z45);
                                string de = Cr.ReadLine();

                                if (de == "1")
                                {
                                    Console.Write("The Result of Encryption Operation is :->>     ");
                                    Console.WriteLine(obj.encryption(z45, Pb, Bb));
                                    string fols = obj.encryption(z45, Pb, Bb);
                                    Cw.WriteLine(fols);

                                }
                                else
                                {
                                    Console.Write("The Result of Decryption Operation is :->>     ");
                                    Console.WriteLine(obj.encryption(z45, Pb, Bb));
                                    string fols = obj.encryption(z45, Pb, Bb);
                                    Cw.WriteLine(fols);

                                }
                                Console.WriteLine("_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
                                Console.WriteLine("  ");
                            }
                            Cw.Close();
                            Csw.Close();
                            break;

                    }
                }

                else if (k == "6")
                {
                    Console.Write("#Enter The Number want to check it: ");
                    string number1 = Console.ReadLine();
                    obj.Odd_even(number1);
                }

            }
            else
                Console.WriteLine("Your Choice is error");

            Console.WriteLine("                 -----------------------------------------------");

            Console.WriteLine("You Want tl3b tani y/n");

            string gain = Console.ReadLine();
            if (gain != "y" && gain != "yes")
                break;

        }



        //string line = Sr.ReadLine();
        //Console.WriteLine("The line in the file is : " + line);
        //Sr.Close();
        //fsr.Close();             
    }
}