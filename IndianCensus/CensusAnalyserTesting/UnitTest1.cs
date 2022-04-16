using NUnit.Framework;
using IndianCensus;

namespace CensusAnalyserTesting
{
    public class Tests
    {
        string folderPath = @"H:\Bridgelabz assignment\IndianCensus\IndianCensus\CSVFiles\";
        string validStateCensusFileState = "IndiaStateCensusData.csv";
        string invalidExtensionFileState = "IndiaStateCode.txt";
        string invalidDelimiterFileState = "DelimiterIndiaStateCensusData.csv";
        string invalidHeaderState = "WrongIndiaStateCensusData.csv";
        CensusAnalyser censusAnalyser;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
        }
        /// <summary>
        /// TC 1.1 - Data loaded or not
        /// </summary>
        [Test]
        public void Given_DataRecord_CSVfileAreSame()
        {
            censusAnalyser.data = censusAnalyser.LoadCensusData(folderPath + validStateCensusFileState, "State,Population,AreaInSqKm,DensityPerSqKm");
            Assert.AreEqual(29, censusAnalyser.data.Count);
        }
        /// <summary>
        /// TC1.2-  Given File is Exist or Not
        /// </summary>
        [Test]
        public void Given_IncorrectCSVFileName_ReturnCustomException()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(folderPath + validStateCensusFileState + "XYZ", "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.File_Not_Exist, exception.type);
        }
        /// <summary>
        /// TC1.3-  Given File is Contains Proper extension or not
        /// </summary>
        [Test]
        public void Given_IncorrectFileType_ReturnCustomException()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(folderPath + invalidExtensionFileState, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.Improper_Extension, exception.type);
        }
        /// <summary>
        /// TC1.4-  Proper delimeter is used or not
        /// </summary> 
        [Test]
        public void Given_IncorrectDelimiter_ReturnCustomException()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(folderPath + invalidDelimiterFileState, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.Deliminator_Not_Found, exception.type);
        }
        /// <summary>
        /// TC1.5- DataHeader is not correct or not
        /// </summary>
        [Test]
        public void Given_IncorrectHeader_ReturnCustomException()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(folderPath + invalidHeaderState, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.Incorrect_Header, exception.type);
        }
    }
}
