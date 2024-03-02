using System.Globalization;

Console.WriteLine("Digite a data de checkin(dd/MM/yyyy): ");
string dataCheckinStr = Console.ReadLine();

DateTime data1 = conversorDeData(dataCheckinStr);

Console.WriteLine("Digite a data de checkout(dd/MM/yyyy): ");
string dataCheckoutStr = Console.ReadLine();

DateTime data2 = conversorDeData(dataCheckoutStr);

DateTime conversorDeData(string dataStr)
{
    return DateTime.ParseExact(dataStr, "dd/MM/yyyy", CultureInfo.InvariantCulture);
}
