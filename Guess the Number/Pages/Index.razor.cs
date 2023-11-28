using System.Net.Http.Headers;
using System.Net.Http.Json;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

using MudBlazor;

using Guess_the_Number.Shared;
using Guess_the_Number.Pages;

using static MudBlazor.CategoryTypes;

using System.Text.Json.Serialization;
using System.Xml;
using Guess_the_Number.Classes;
using System.Security.AccessControl;

namespace Guess_the_Number.Pages;

public partial class Index
{
    // Classes
    public Number GenNum = new Number();
    public List<string> GenNumList = new List<string>();
    public List<GameType> GameTypeList = new List<GameType>();
    public GameType GameTypeSelected = new GameType();

    // Variáveis

    // Ints
    public int? GuessInt;
    public decimal? GuessDecimal;

    // Strings
    public string? GuessType;


    // Main
    protected override async Task OnInitializedAsync()
    {
        // Int Game
        GameType newGameTypeInteger = new GameType();

        newGameTypeInteger.Id = GameTypeList.Count;
        newGameTypeInteger.Name = Variables.Integer.ToString();
        newGameTypeInteger.Type = Variables.Integer;
        newGameTypeInteger.AcessKey = "I";
        GameTypeList.Add(newGameTypeInteger);


        // Decimal Game
        GameType newGameTypeDecimal = new GameType();

        newGameTypeDecimal.Id = GameTypeList.Count;
        newGameTypeDecimal.Name = Variables.Decimal.ToString();
        newGameTypeDecimal.Type = Variables.Decimal;
        newGameTypeDecimal.AcessKey = "D";
        GameTypeList.Add(newGameTypeDecimal);
    }

    public async void TryGuess()
    {
        if(string.IsNullOrEmpty(GuessType))
        {
            await Alert("Please, select the game type before play.", "Ok", Color.Error);
            return;
        }

        GameTypeSelected = GameTypeList.Find(e => e.AcessKey == GuessType);

        // Integer
        if (GuessType == "I")
        {
            if(GuessInt < 0 || GuessInt > 10)
            {
                await Alert("Min: 0 - Max: 10", "Ok", Color.Error);
                return;
            }

            int GeneratedNumber = await GetIntAsync();

            if(GeneratedNumber == GuessInt)
            {

            }
            else
            {

            }
            Console.WriteLine($"DEBUG: Número gerado: {GeneratedNumber} - Número escolhido pelo usuário: {GuessInt}");

        }
        // Decimal
        else if (GuessType == "D")
        {
            if (GuessDecimal < 0 || GuessDecimal > 10)
            {
                await Alert("Min: 0 - Max: 10", "Ok", Color.Error);
                return;
            }

            decimal GeneratedNumber = await GetDecimalAsync();

            if (GeneratedNumber == GuessDecimal)
            {

            }
            else
            {

            }
            Console.WriteLine($"DEBUG: Número gerado: {GeneratedNumber} - Número escolhido pelo usuário: {GuessDecimal}");
        }
    }

    public async Task<int> GetIntAsync()
    {
        int value = 0;

        Random _r = new Random();
        value = _r.Next(1, 10);

        return value;
    }


    public async Task<decimal> GetDecimalAsync()
    {
        double value = 0;

        Random _r = new Random();
        value = _r.NextDouble();

        return (decimal)value;
    }


    // System Alert
    async Task Alert(string Message, string Button, Color Color)
    {
        var parameters = new DialogParameters();
        parameters.Add("ContentText", Message);
        parameters.Add("ButtonText", Button);
        parameters.Add("Color", Color);
        var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.Small };
        DialogService.Show<DialogBox>("SYSTEM ALERT", parameters, options);
    }

}