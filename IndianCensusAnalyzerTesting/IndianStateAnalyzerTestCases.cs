using IndianCensusAnalyzer;
using IndianCensusAnalyzer.DTO;

namespace IndianCensusAnalyzerTesting
{
    [TestClass]
    public class IndianStateAnalyzerTestCases
    {
        string stateCensusFilePath = @"C:\Users\shrey\source\repos\IndianCensusAnalyzer\IndianCensusAnalyzer\CSVFiles\IndianPopulation.csv";
        string wrongFilePath = @"C:\Users\shrey\source\repos\IndianCensusAnalyzer\IndianCensusAnalyzer\CSVFiles\WrongIndianPopulation.csv";
        string wrongTypeFilePath = @"C:\Users\shrey\source\repos\IndianCensusAnalyzer\IndianCensusAnalyzer\CSVFiles\IndianPopulation.txt";
        string wrongDelimiterFilePath = @"C:\Users\shrey\source\repos\IndianCensusAnalyzer\IndianCensusAnalyzer\CSVFiles\DelimiterIndiaStateCensusData.csv";
        string wrongHeaderFilePath = @"C:\Users\shrey\source\repos\IndianCensusAnalyzer\IndianCensusAnalyzer\CSVFiles\WrongIndiaStateCensusData.csv";

        CSVAdapterFactory csvAdapter;
        Dictionary<string, CensusDTO> stateRecords;

        [TestInitialize]
        public void SetUp()
        {
            csvAdapter = new CSVAdapterFactory();
            stateRecords = new Dictionary<string, CensusDTO>();
        }

        //TC 1.1 Given correct path To ensure number of records matches
        [TestMethod]
        public void GivenStateCensusCsvReturnStateRecords()
        {
            int expected = 29;
            stateRecords = csvAdapter.LoadCsvData(CensusAnalyzer.Country.INDIA, stateCensusFilePath, "State,Population,AreaInSqKm,DensityPerSqKm");
            Assert.AreEqual(expected, stateRecords.Count);
        }

        //TC 1.2 Given incorrect file should return custom exception - File not found
        [TestMethod]
        public void GivenWrongFileReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.FILE_NOT_FOUND;
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyzer.Country.INDIA, wrongFilePath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 1.3 Given correct path but incorrect file type should return custom exception - Invalid file type
        [TestMethod]
        public void GivenWrongFileTypeReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE;
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyzer.Country.INDIA, wrongTypeFilePath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 1.4 Given correct path but wrong delimiter should return custom exception - File Containers Wrong Delimiter
        [TestMethod]
        public void GivenWrongDelimiterReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INCOREECT_DELIMITER;
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyzer.Country.INDIA, wrongDelimiterFilePath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(expected, customException.exception);
        }

        //TC 1.5 Given correct path but wrong header should return custom exception - Incorrect header in Data
        [TestMethod]
        public void GivenWrongHeaderReturnCustomException()
        {
            var expected = CensusAnalyserException.ExceptionType.INCORRECT_HEADER;
            var customException = Assert.ThrowsException<CensusAnalyserException>(() => csvAdapter.LoadCsvData(CensusAnalyzer.Country.INDIA, wrongHeaderFilePath, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(expected, customException.exception);
        }
    }
}