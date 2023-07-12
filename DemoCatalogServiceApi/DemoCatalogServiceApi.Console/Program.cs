namespace DemoCatalogServiceApi.Console
{
    class Program
    {
        private static readonly HttpClient Client = new HttpClient();

        static void ShowProduct(string info)
        {
            System.Console.WriteLine(info);
        }

        static async Task Main(string[] args)
        {
            var requestUrl = "https://localhost:5001";

            System.Console.WriteLine("Enter category Id: ");
            var id = System.Console.ReadLine();
            var categoryRequestUrl = requestUrl + "/category";

            var message = new HttpRequestMessage(HttpMethod.Get, $"{categoryRequestUrl}/{id}") { Version = new Version(2, 0) };

            var request = await Client.SendAsync(message);

            ShowProduct(await request.Content.ReadAsStringAsync());

            System.Console.WriteLine("Enter criteria product: ");
            System.Console.WriteLine("Category ID: ");

            var categoryID = System.Console.ReadLine();
            System.Console.WriteLine("Page number: ");
            var pageNumber = System.Console.ReadLine();
            System.Console.WriteLine("Page size: ");
            var pageSize = System.Console.ReadLine();

            var response = new HttpResponseMessage();

            var formDataContent = new MultipartFormDataContent();

            formDataContent.Add(new StringContent(categoryID), "CategoryID");
            formDataContent.Add(new StringContent(pageNumber), "PageNumber");
            formDataContent.Add(new StringContent(pageSize), "PageSize");

            var productRequestUrl = requestUrl + "/product/criteria";

            response = await Client.PostAsync(productRequestUrl, formDataContent);
            ShowProduct(await response.Content.ReadAsStringAsync());

            System.Console.ReadKey();

        }
    }
}
