using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace customized_base64
{
    class Program
    {
        //인코딩 테이블
        private static char[] arrEntable = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
        ,'A','B','C','D','E','F','G','H','I','J','K','l','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
        ,'0','1','2','3','4','5','6','7','8','9','+','/'};

        //파일에 있던 값을 char배열로 변환관련 변수
        private static char[] chArr;
        //변환된 이진수 저장
        private static ArrayList arrayBinary = new ArrayList();
        //변환된 10진수 저장
        private static ArrayList arrayDecimal = new ArrayList();
        //binary.bin파일이 존재하는 경로
        private static string strFilePath = System.Environment.CurrentDirectory.ToString() + "\\binary.bin";
        //파일의 내용
        private static string strFileContent = "";

        static void Main(string[] args)
        {
            //파일 존재시 다음 순서 진행
            if (fileCheck())
            {
                //파일 읽어오기
                fileLoad();
                //2진수로 변경
                changeBinary(strFileContent);
                //2진수를 6비트단위로 나누어 10진수로 변경
                changeDecimal();
                //변경된 10진수와 인코딩테이블 비교후 디코딩
                decoding();
            }
        }

        //파일 존재유무 체크
        private static bool fileCheck()
        {
            if (System.IO.File.Exists(strFilePath))
            {
                return true;
            }
            else
            {
                Console.WriteLine("binary.bin 파일이 존재하지 않습니다.");
                return false;
            }

        }
        //파일 내용 읽기
        private static void fileLoad()
        {
            strFileContent = File.ReadAllText(strFilePath);
            Console.WriteLine("읽어들인 파일 내용 : " + strFileContent);
        }

        //2진수로 변환
        private static void changeBinary(string strfilecontent)
        {
            chArr = strfilecontent.ToCharArray();
            int iTemp = 0;
            for (int i = 0; i < chArr.Length; i++)
            {
                if (chArr[i] != ' ')
                {
                    //16진수 코드 정리
                    if (chArr[i] == 'a' || chArr[i] == 'b' || chArr[i] == 'c' || chArr[i] == 'd' || chArr[i] == 'e' || chArr[i] == 'f')
                    {
                        switch (chArr[i])
                        {
                            case 'a':
                                iTemp = 10;
                                break;
                            case 'b':
                                iTemp = 11;
                                break;
                            case 'c':
                                iTemp = 12;
                                break;
                            case 'd':
                                iTemp = 13;
                                break;
                            case 'e':
                                iTemp = 14;
                                break;
                            case 'f':
                                iTemp = 15;
                                break;

                        }
                    }
                    else
                    {
                        iTemp = int.Parse(chArr[i].ToString());
                    }


                    //2진수로 변환
                    int j = -1;
                    int nmg, mok;
                    int[] arrTemp = new int[10];

                    do
                    {
                        ++j;
                        mok = iTemp / 2;
                        nmg = iTemp - mok * 2;
                        arrTemp[j] = nmg;
                        iTemp = mok;
                    } while (mok != 0);


                    for (int k = 3; k >= 0; k--)
                    {
                        arrayBinary.Add(arrTemp[k]);
                    }
                }
            }
        }

        private static void changeDecimal()
        {
            //6비트로 단위로 10진수로 변경
            int count = 5;
            int sum = 0;

            for (int i = 0; i < arrayBinary.Count; i++)
            {


                //10진수로 변환
                int itemp = int.Parse(arrayBinary[i].ToString()) * int.Parse(Math.Pow(2, count).ToString());

                sum += itemp;

                count--;
                if (count < 0)
                {
                    count = 5;
                    arrayDecimal.Add(sum);
                    sum = 0;
                }
            }
        }
        //인코딩테이블 참고하여 출력
        private static void decoding()
        {
            string strTemp = "";
            for (int i = 0; i < arrayDecimal.Count; i++)
            {
                int n = int.Parse(arrayDecimal[i].ToString());
                strTemp += (arrEntable[n]);
            }
            Console.WriteLine("디코딩 결과 : " + strTemp);
        }


    }
}
