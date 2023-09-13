namespace BenchmarkingExample
{
    public class DateParser
    {
        public int GetYearFromDateTime(string dateTimeAsString)
        {
            var datTime = DateTime.Parse(dateTimeAsString);

            return datTime.Year;
        }
        public int GetYearFromSplit(string dateTimeAsString)
        {
            var splitOnHypen = dateTimeAsString.Split('-');

            return int.Parse(splitOnHypen[0]);

        } 
        public int GetYearFromSubstring(string dateTimeAsString)
        {
            var indexOfHypen = dateTimeAsString.IndexOf('-');

            return int.Parse(dateTimeAsString.Substring(0, indexOfHypen));

        }
        public int GetYearFromSpan(ReadOnlySpan<char> dateTimeAsSpan)
        {
            var indexOfHypen = dateTimeAsSpan.IndexOf('-');

            return int.Parse(dateTimeAsSpan.Slice(0, indexOfHypen));

        }
    }
}
