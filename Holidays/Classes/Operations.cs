using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace Holidays.Classes;

internal class Operations
{
    public static async Task Run(string countryCode = "AU")
    {
        var jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        using var httpClient = new HttpClient();
        
        var response = await httpClient.GetAsync(
            $"https://date.nager.at/api/v3/publicholidays/{DateTime.Now.Year}/{countryCode}");

        if (response.IsSuccessStatusCode)
        {
            await using var jsonStream = await response.Content.ReadAsStreamAsync();

            // Distinct is used as there were duplicate entries
            var publicHolidays = 
                JsonSerializer.Deserialize<PublicHoliday[]>(jsonStream, jsonSerializerOptions)
                    !.Distinct(PublicHoliday.DateComparer);

            AnsiConsole.MarkupLine($"[yellow]Holidays[/]");

            var table = new Table()
                .RoundedBorder()
                .AddColumn("[b]Name[/]")
                .AddColumn("[b]Date[/]")
                .Alignment(Justify.Left)
                .BorderColor(Color.CadetBlue);

            foreach (var holiday in publicHolidays!)
            {

                if (holiday.Date > DateTime.Now)
                {
                    table.AddRow($"[cyan]{holiday.Name}[/]", $"[white]{holiday.Date:MM/dd/yyyy}[/]");
                }
                else
                {
                    table.AddRow(holiday.Name, holiday.Date.ToString("MM/dd/yyyy"));
                }
            }


            AnsiConsole.Write(table);
        }

    }
}