using MauiBug_SearchHandler_iOSCrash.Models;
using System.Reflection;
using System.Text.Json;

namespace MauiBug_SearchHandler_iOSCrash.Controls
{
    public class PlayerSearchHandler : SearchHandler
    {

        protected override async void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue) || newValue.Length <= 2)
            {
                ItemsSource = null;
            }
            else
            {

                try
                {
                    var a = Assembly.GetExecutingAssembly();
                    using var stream = a.GetManifestResourceStream("MauiBug_SearchHandler_iOSCrash.Models.search.json");
                    var result = JsonSerializer.DeserializeAsync<List<Search>>(stream,
                        new JsonSerializerOptions
                        {
                            NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString | System.Text.Json.Serialization.JsonNumberHandling.WriteAsString

                        }
                        ).Result;

                    ItemsSource = result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);

            this.Unfocus();

            // The following route works because route names are unique in this app.
            await Shell.Current.GoToAsync($"secondpage");
        }

    }
}
