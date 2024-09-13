using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;

internal class WebAngeloni
{
    static void Main(string[] args)
    {
        //string linkTxt = @"C:\Users\suele\Desktop\Maria Maria\VStudio22\AngeloniLinks.txt";
        //string priceTxt = @"C:\Users\suele\Desktop\Maria Maria\VStudio22\AngeloniPrecos.txt";
        string linkTxt = @"C:\Users\Crawler\Desktop\Maria Maria\VStudio22\AngeloniLinks.txt";
        string priceTxt = @"C:\Users\Crawler\Desktop\Maria Maria\VStudio22\AngeloniPrecos.txt";
        var listaLinks = new List<string> { };
        var listaPrices = new List<string> { };
        string dadosListaLink;


        //https://www.angeloni.com.br/super/confirmacao-entrega?register=success&_requestid=439120 pagina p selecionar retirada

        //if (File.Exists(@"C:\Users\suele\Desktop\Maria Maria\VStudio22\AngeloniLinks.txt"))
        if (File.Exists(@"C:\Users\Crawler\Desktop\Maria Maria\VStudio22\AngeloniLinks.txt"))
        {
            using (StreamReader sr = new StreamReader(linkTxt)) //se arquivo n existir voltar p o menu
            {
                Console.WriteLine("Lista de usuários atual:");
                while ((dadosListaLink = sr.ReadLine()) != null)
                {
                    listaLinks.Add(dadosListaLink);
                    Console.WriteLine(dadosListaLink);
                }
                sr.Close();
            }
            var totalItens = listaLinks.Count;
            Console.WriteLine("");
            Console.WriteLine("Total de itens:");
            Console.WriteLine(totalItens);
            Console.WriteLine("");

            //var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArguments("headless");
            //IWebDriver driver = new ChromeDriver(chromeOptions);
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.angeloni.com.br/super");
            Thread.Sleep(4000);
            //driver.FindElement(By.XPath("/html/body/header/div[2]/div[4]/div[6]/a/strong")).Click();
            //Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html/body/header/div[2]/div[4]/div[6]")).Click();
            Thread.Sleep(3000);

            var loginLocation = driver.FindElement(By.XPath("/html/body/div[18]/div/div[1]/div[1]/form/label[1]/input[1]"));
            loginLocation.SendKeys("login@mariamaria.app");
            Thread.Sleep(2000);

            //driver.FindElement(By.XPath("/html/body/div[17]/div/div[1]/div[1]/form/label[2]/input[1]")).Click();
            var passwordLocation = driver.FindElement(By.XPath("//*[@id=\"pass\"]"));

            passwordLocation.SendKeys("senha");
            Thread.Sleep(3000);

            //*[@id="loginSubmit"]
            driver.FindElement(By.XPath("/html/body/div[18]/div/div[1]/div[1]/form/div/button")).Click();
            
            //driver.FindElement(By.Id("loginSubmit")).Click();

            //driver.FindElement(By.XPath("//*[@id=\"loginSubmit\"]")).Click();

            Thread.Sleep(2000);

            driver.FindElement(By.Id("modal-alterar-senha-meus-dados")).Click();

            Thread.Sleep(2000);


            /*if (enterLogin.Count > 0)
            {
                driver.FindElement(By.XPath("/html/body/div[17]/div/div[1]/div[1]/form/div/button")).Click();
            }
            else
            {
                driver.FindElement(By.XPath("//*[@id=\"change - password\"]/div/input[1]")).Click();
            }*/

            //fechar janela de mudar senha
            driver.FindElement(By.XPath("//*[@id=\"modal-alterar-senha-meus-dados\"]/a")).Click();


            Thread.Sleep(2000); //*[@id="change-password"]/div/input[1]

            //select location
            driver.FindElement(By.XPath("//*[@id=\"radioWithdrawInStore\"]")).Click();
            Thread.Sleep(500);

            //select options Location
            driver.FindElement(By.XPath("//*[@id=\"formAddressDelivery\"]/div[1]/div/div/div[3]/div[1]")).Click();
            Thread.Sleep(1000);
            Console.WriteLine("");
            Console.WriteLine("ESCOLHA O SUPERMERCADO PARA CAPTURAR PREÇO");
            Console.WriteLine("");
            Console.WriteLine("1 - ANGELONI QUARTA AVENIDA (Balneário Camboriú / SC)");
            Console.WriteLine("2 - ANGELONI BEIRA MAR (Florianópolis / SC)");
            Console.WriteLine("3 - ANGELONI BIGORRILHO (Curitiba / PR)");
            Console.WriteLine("4 - ANGELONI CAPOEIRAS (Florianópolis / SC)");
            Console.WriteLine("5 - ANGELONI BERNARDO GRUBBA (Jaraguá do Sul / SC)");
            Console.WriteLine("6 - ANGELONI CENTENÁRIO (Criciúma / SC)");
            Console.WriteLine("7 - ANGELONI JARDIM ATLANTICO (Florianópolis / SC)");
            Console.WriteLine("8 - ANGELONI JOÃO COLLIN (Joinville / SC)");
            Console.WriteLine("9 - ANGELONI LAGES (Lages / SC)");
            Console.WriteLine("10 - ANGELONI LONDRINA (Londrina / PR)");
            Console.WriteLine("11 - ANGELONI Maringá (Maringá / PR)");
            Console.WriteLine("12 - ANGELONI PORTO BELO/MEIA PRAIA (Porto Belo / SC)");
            Console.WriteLine("13 - ANGELONI TUBARÃO (Tubarão / SC)");
            Console.WriteLine("14 - ANGELONI VELHA (Blumenau / SC)");
            Console.WriteLine("");



            var select = Console.ReadLine();
            var repeat = 0;

            while(repeat < 1)
            {
                switch (select)
                {
                    case "1":  //select market BEIRA MAR (FLORIPA)
                        driver.FindElement(By.XPath($"//*[@id=\"formAddressDelivery\"]/div[1]/div/div/div[3]/div[2]/div[1]")).Click();
                        Thread.Sleep(1000);
                        repeat = 1;
                        break;

                    case "2": //select market CAPOEIRAS (FLORIPA)
                        driver.FindElement(By.XPath($"//*[@id=\"formAddressDelivery\"]/div[1]/div/div/div[3]/div[2]/div[2]")).Click();
                        Thread.Sleep(1000);
                        repeat = 1;

                        break;

                    case "3": //select market JARDIM ATLANTICO (FLORIPA)
                        driver.FindElement(By.XPath("//*[@id=\"formAddressDelivery\"]/div[1]/div/div/div[3]/div[2]/div[3]")).Click();
                        Thread.Sleep(1000);
                        repeat = 1;

                        break;

                    case "4"://select marke BIGORRILHO (CURITIBA)
                        driver.FindElement(By.XPath("//*[@id=\"formAddressDelivery\"]/div[1]/div/div/div[3]/div[2]/div[4]")).Click();
                        Thread.Sleep(1000);
                        repeat = 1;

                        break;
                        ////////////////////////////
                    case "5":  //select market BEIRA MAR (FLORIPA)
                        driver.FindElement(By.XPath($"//*[@id=\"formAddressDelivery\"]/div[1]/div/div/div[3]/div[2]/div[5]")).Click();
                        Thread.Sleep(1000);
                        repeat = 1;
                        break;

                    case "6": //select market CAPOEIRAS (FLORIPA)
                        driver.FindElement(By.XPath("//*[@id=\"formAddressDelivery\"]/div[1]/div/div/div[3]/div[2]/div[6]")).Click();
                        Thread.Sleep(1000);
                        repeat = 1;

                        break;

                    case "7": //select market JARDIM ATLANTICO (FLORIPA)
                        driver.FindElement(By.XPath("//*[@id=\"formAddressDelivery\"]/div[1]/div/div/div[3]/div[2]/div[7]")).Click();
                        Thread.Sleep(1000);
                        repeat = 1;

                        break;

                    case "8"://select marke BIGORRILHO (CURITIBA)
                        driver.FindElement(By.XPath("//*[@id=\"formAddressDelivery\"]/div[1]/div/div/div[3]/div[2]/div[8]")).Click();
                        Thread.Sleep(1000);
                        repeat = 1;

                        break;

                    ////////////////////////////
                    case "9":  //select market BEIRA MAR (FLORIPA)
                        driver.FindElement(By.XPath($"//*[@id=\"formAddressDelivery\"]/div[1]/div/div/div[3]/div[2]/div[9]")).Click();
                        Thread.Sleep(1000);
                        repeat = 1;
                        break;

                    case "10": //select market CAPOEIRAS (FLORIPA)
                        driver.FindElement(By.XPath("//*[@id=\"formAddressDelivery\"]/div[1]/div/div/div[3]/div[2]/div[10]")).Click();
                        Thread.Sleep(1000);
                        repeat = 1;

                        break;

                    case "11": //select market JARDIM ATLANTICO (FLORIPA)
                        driver.FindElement(By.XPath("//*[@id=\"formAddressDelivery\"]/div[1]/div/div/div[3]/div[2]/div[11]")).Click();
                        Thread.Sleep(1000);
                        repeat = 1;

                        break;

                    case "12"://select marke BIGORRILHO (CURITIBA)
                        driver.FindElement(By.XPath("//*[@id=\"formAddressDelivery\"]/div[1]/div/div/div[3]/div[2]/div[12]")).Click();
                        Thread.Sleep(1000);
                        repeat = 1;

                        break;

                    case "13"://select marke BIGORRILHO (CURITIBA)
                        driver.FindElement(By.XPath("//*[@id=\"formAddressDelivery\"]/div[1]/div/div/div[3]/div[2]/div[13]")).Click();
                        Thread.Sleep(1000);
                        repeat = 1;

                        break;

                    case "14"://select marke BIGORRILHO (CURITIBA)
                        driver.FindElement(By.XPath("//*[@id=\"formAddressDelivery\"]/div[1]/div/div/div[3]/div[2]/div[14]")).Click();
                        Thread.Sleep(1000);
                        repeat = 1;

                        break;

                    default:
                        Console.WriteLine("OPÇÃO INVALIDA, EXECUTE O PROGRAMA NOVAMENTE");
                        repeat = 0;

                        break;
                }
            }

            //confirm location
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//*[@id=\"formAddressDelivery\"]/div[5]/a/b")).Click();

            Thread.Sleep(2000);
            var counter = 0;

            foreach (var product in listaLinks)
            {
                Thread.Sleep(500);
                driver.Navigate().GoToUrl(product);
                Thread.Sleep(2000);
                //driver.FindElement(By.Id("modal-alterar-senha-meus-dados")).Click();
                driver.FindElement(By.XPath("//*[@id=\"modal-alterar-senha-meus-dados\"]/a")).Click();
                Thread.Sleep(500);

                var Promo2 = driver.FindElements(By.XPath("//*[@id=\"container\"]/div[3]/div[5]/div/div[1]/div/div/div[2]/span[2]"));
                if (Promo2.Count == 0)
                {
                    //*[@id="container"]/div[3]/div[5]/div/div[1]/div/div/div[2]
                    var Promo1 = driver.FindElements(By.XPath("/html/body/div[13]/div[2]/div[3]/div[3]/div[5]/div/div[1]/div/div/div[2]"));

                    if (Promo1.Count == 0)
                    {
                        var priceNormalReal = driver.FindElements(By.XPath("//*[@id=\"container\"]/div[3]/div[5]/div/div[1]/div/div[1]/span[2]"));
                        //var priceNormalCents = driver.FindElements(By.XPath("///*[@id=\"container\"]/div[3]/div[5]/div/div[1]/div/div[1]/span[3]/div[1]"));
                        if (priceNormalReal.Count == 0 )
                        {
                            Debug.Print("0,00");
                            listaPrices.Add("0,00");
                            counter++;
                            Console.WriteLine($"{counter} de {totalItens}");
                            Console.WriteLine("0,00");
                        }
                        else //*[@id=\"product - details\"]/div[2]/div[3]/div[6]/div[2]/div[1]/div/div/div[2]/span[2]
                        {
                            var priceReal = driver.FindElement(By.XPath("//*[@id=\"container\"]/div[3]/div[5]/div/div[1]/div/div[1]/span[2]"));
                            var priceCents = driver.FindElement(By.XPath("//*[@id=\"container\"]/div[3]/div[5]/div/div[1]/div/div[1]/span[3]/div[1]"));
                            listaPrices.Add($"{priceReal.Text},{priceCents.Text}");
                            Debug.Print($"{priceReal.Text},{priceCents.Text}");
                            counter++;
                            Console.WriteLine($"{counter} de {totalItens}");
                            Console.WriteLine($"{priceReal.Text},{priceCents.Text}");
                        }
                    }
                    else
                    {
                        var pricePromo1 = driver.FindElement(By.XPath("/html/body/div[13]/div[2]/div[3]/div[3]/div[5]/div/div[1]/div/div/div[2]"));
                        listaPrices.Add(pricePromo1.Text);
                        Debug.Print(pricePromo1.Text);
                        counter++;
                        Console.WriteLine($"{counter} de {totalItens}");
                        Console.WriteLine(pricePromo1.Text);
                    }
                }
                else
                {
                    var realPromo2 = driver.FindElement(By.XPath("//*[@id=\"container\"]/div[3]/div[5]/div/div[1]/div/div/div[2]/span[2]"));
                    var centsPromo2 = driver.FindElement(By.XPath("//*[@id=\"container\"]/div[3]/div[5]/div/div[1]/div/div/div[2]/span[3]/div[1]"));

                    listaPrices.Add($"{realPromo2.Text},{centsPromo2.Text}");
                    Debug.Print($"{realPromo2.Text},{centsPromo2.Text}");
                    counter++;
                    Console.WriteLine($"{counter} de {totalItens}");
                    Console.WriteLine($"{realPromo2.Text},{centsPromo2.Text}");
                }

            }

            using (StreamWriter sw = new StreamWriter(priceTxt))
            {
                for (var aux1 = 0; aux1 < listaPrices.Count; aux1++)
                {
                    sw.WriteLine($"{listaPrices[aux1]}");
                }
                sw.Close();
            }
            Console.WriteLine("");
            Console.WriteLine("OPERAÇÃO CONCLUÍDA!!!");
            Console.WriteLine("");
            Console.ReadKey();

        }

        else
        {
            Console.WriteLine("");
            Console.WriteLine("LISTA INEXISTENTE!");
            Console.WriteLine("");
        }

        Console.ReadKey();

    }

}
