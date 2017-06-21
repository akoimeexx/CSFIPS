using System;
using System.Collections.Generic;
using libfips;

namespace Test.libfips.CLI {
    
    class Program {
        static void Main(string[] args) {
            // Simple GetCounty fetch:
            List<FipsRecord> FLCounties = new List<FipsRecord>(FIPS.GetCounties(State.FL));
            Console.WriteLine(
                "{0}, {1}: {2}",
                FLCounties[0].CountyName,
                FLCounties[0].StatePostalCode.ToString(),
                FLCounties[0].FipsCode
            );
            // Simple Search fetch:
            List<FipsRecord> SingleCounty = new List<FipsRecord>(FIPS.Search("saginaw"));
            Console.WriteLine(
                "{0}, {1}: {2}", 
                SingleCounty[0].CountyName, 
                SingleCounty[0].StatePostalCode.ToString(), 
                SingleCounty[0].FipsCode
            );
            // Simple Count of Search results:
            List<FipsRecord> SearchResults = new List<FipsRecord>(FIPS.Search("mi"));
            Console.WriteLine(
                "Total Records Found for search token \"mi\": {0}", SearchResults.Count
            );
            // Simple Count of State-Only Search results:
            List<FipsRecord> StateSearchResults = new List<FipsRecord>(FIPS.Search("mi", SearchMethod.State));
            Console.WriteLine(
                "Total Records Found for state search token \"mi\": {0}", StateSearchResults.Count
            );
            // Simple Count of County-Only Search results:
            List<FipsRecord> CountySearchResults = new List<FipsRecord>(FIPS.Search("mi", SearchMethod.County));
            Console.WriteLine(
                "Total Records Found for county search token \"mi\": {0}", CountySearchResults.Count
            );
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
