using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;

internal class WebAngeloni
{
    static void Main(string[] args)
    {
        string linkTxt = @"C:\Users\suele\Desktop\Maria Maria\VStudio22\linksAngeloni.txt";
        string priceTxt = @"C:\Users\suele\Desktop\Maria Maria\VStudio22\precosAngeloni.txt";
        var listaLinks = new List<string> { };
        var listaPrices = new List<string> { };
        var listaPromos = new List<string> { };
        string dadosListaLink;

        if (File.Exists(@"C:\Users\suele\Desktop\Maria Maria\VStudio22\linksAngeloni.txt"))
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

            IWebDriver driver = new ChromeDriver();

            foreach (var product in listaLinks)
            {
                driver.Navigate().GoToUrl("https://www.angeloni.com.br/super/");
                var element = driver.FindElement(By.XPath("//*[@id=\"search_box_desktop\"]")); //encontrar caixa para digitar texto
                element.Clear();
                element.SendKeys(product); //inclui texto na caixa de pesquisa
                Thread.Sleep(6000);

                //criar uma lista p receber as tags
                var tagSite1 = driver.FindElements(By.XPath("/html/body/header/div[2]/div[4]/div[1]/div[2]/div/div/div[2]/a/div[2]"));
                var tagSite2 = driver.FindElements(By.XPath("/html/body/header/div[2]/div[4]/div[1]/div[2]/div/div/div[3]/a/div[2]"));
                var tagSite3 = driver.FindElements(By.XPath("/html/body/header/div[2]/div[4]/div[1]/div[2]/div/div/div[4]/a/div[2]"));

                if (tagSite1.Count > 0)
                {
                    var tagCompare1 = driver.FindElement(By.XPath("/html/body/header/div[2]/div[4]/div[1]/div[2]/div/div/div[2]/a/div[2]"));
                    if (tagCompare1.Text == product)
                    {
                        var pricePromo1 = driver.FindElements(By.XPath("/html/body/header/div[2]/div[4]/div[1]/div[2]/div/div/div[2]/div[1]/span[2]"));
                        if (pricePromo1.Count > 0)
                        {
                            var pricePromo = driver.FindElement(By.XPath("/html/body/header/div[2]/div[4]/div[1]/div[2]/div/div/div[2]/div[1]/span[2]"));
                            listaPrices.Add(pricePromo.Text);
                            Debug.Print(product);
                            Debug.Print(pricePromo.Text);
                        }
                        else
                        {
                            var price = driver.FindElement(By.XPath("/html/body/header/div[2]/div[4]/div[1]/div[2]/div/div/div[2]/div[1]"));
                            listaPrices.Add(price.Text);
                            Debug.Print(product);
                            Debug.Print(price.Text);
                        }
                    }
                    else if (tagSite2.Count > 0)
                    {
                        var tagCompare2 = driver.FindElement(By.XPath("/html/body/header/div[2]/div[4]/div[1]/div[2]/div/div/div[3]/a/div[2]"));
                        if (tagCompare2.Text == product)
                        {
                            var pricePromo2 = driver.FindElements(By.XPath("/html/body/header/div[2]/div[4]/div[1]/div[2]/div/div/div[3]/div[1]/span[2]"));
                            if (pricePromo2.Count > 0)
                            {
                                var pricePromo = driver.FindElement(By.XPath("/html/body/header/div[2]/div[4]/div[1]/div[2]/div/div/div[3]/div[1]/span[2]"));
                                listaPrices.Add(pricePromo.Text);
                                Debug.Print(product);
                                Debug.Print(pricePromo.Text);
                            }
                            else
                            {
                                var price = driver.FindElement(By.XPath("/html/body/header/div[2]/div[4]/div[1]/div[2]/div/div/div[3]/div[1]"));
                                listaPrices.Add(price.Text);
                                Debug.Print(product);
                                Debug.Print(price.Text);
                            }
                        }
                        else if (tagSite3.Count > 0)
                        {
                            var tagCompare3 = driver.FindElement(By.XPath("/html/body/header/div[2]/div[4]/div[1]/div[2]/div/div/div[4]/a/div[2]"));
                            if (tagCompare3.Text == product)
                            {
                                var pricePromo3 = driver.FindElements(By.XPath("/html/body/header/div[2]/div[4]/div[1]/div[2]/div/div/div[4]/div[1]/span[2]"));
                                if (pricePromo3.Count > 0)
                                {
                                    var pricePromo = driver.FindElement(By.XPath("/html/body/header/div[2]/div[4]/div[1]/div[2]/div/div/div[4]/div[1]/span[2]"));
                                    listaPrices.Add(pricePromo.Text);
                                    Debug.Print(product);
                                    Debug.Print(pricePromo.Text);
                                }
                                else
                                {
                                    var price = driver.FindElement(By.XPath("/html/body/header/div[2]/div[4]/div[1]/div[2]/div/div/div[4]/div[1]"));
                                    listaPrices.Add(price.Text);
                                    Debug.Print(product);
                                    Debug.Print(price.Text);
                                }
                            }
                            else
                            {
                                Debug.Print($"{product}");
                                Debug.Print("R$ 0,00");
                                listaPrices.Add("R$ 0,00");
                            }
                        }
                        else
                        {
                            Debug.Print($"{product}");
                            Debug.Print("R$ 0,00");
                            listaPrices.Add("R$ 0,00");
                        }
                    }
                    else
                    {
                        Debug.Print($"{product}");
                        Debug.Print("R$ 0,00");
                        listaPrices.Add("R$ 0,00");
                    }
                }
                else if (tagSite1.Count == 0)
                {
                    Debug.Print($"{product}");
                    Debug.Print("R$ 0,00");
                    listaPrices.Add("R$ 0,00");
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
            Console.WriteLine("OPERAÇÃO CONCLUÍDA!!!");
            Console.ReadKey();

        }

        else
        {
            Console.WriteLine("LISTA INEXISTENTE!");
        }

        Console.ReadKey();

    }

}
