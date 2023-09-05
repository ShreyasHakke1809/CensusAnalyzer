using IndianCensusAnalyzer.DTO;

namespace IndianCensusAnalyzer
{
    public class CSVAdapterFactory
    {
        public Dictionary<string, CensusDTO> LoadCsvData(CensusAnalyzer.Country country, string csvFilePath, string dataHeaders)
        {
            try
            {
                switch (country)
                {
                    case (CensusAnalyzer.Country.INDIA):
                        return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);
                    //case (CensusAnalyser.Country.US):
                    //    return new USCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);
                    default:
                        throw new CensusAnalyserException("No Such Country", CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY);

                }
            }
            catch (CensusAnalyserException ex)
            {
                throw ex;
            }
        }
    }
}
