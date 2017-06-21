namespace libfips {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public static partial class FIPS {
#region Properties
        public static IEnumerable<FipsRecord> Records {
            get {
                if (object.Equals(_records, null))
                    _records = load();
                return _records;
            }
        } private static IEnumerable<FipsRecord> _records = null;
#endregion Properties
    }
    public static partial class FIPS {
#region Methods
        private static IEnumerable<FipsRecord> load() {
            List<FipsRecord> o = new List<FipsRecord>();
            Assembly a = Assembly.GetExecutingAssembly();
            string record = null;
            using (
                StreamReader sr = new StreamReader(a.GetManifestResourceStream(
                    String.Format(
                        "{0}.national_county.csv",
                        typeof(FIPS).Namespace
                    )
                )
            )) while(!object.Equals((record = sr.ReadLine()), null)) {
                string[] fields = record.Split(
                    new char[] { ',' }, 
                    StringSplitOptions.None
                );
                if (fields.Length == 5) {
                    State state = State.Unknown;
                    Enum.TryParse(fields[0], out state);
                    int stateFips = 0;
                    int.TryParse(fields[1], out stateFips);
                    int countyFips = 0;
                    int.TryParse(fields[2], out countyFips);
                    FipsClassCode classCode = FipsClassCode.Unknown;
                    Enum.TryParse(fields[4], out classCode);
                    o.Add(new FipsRecord(
                        state, stateFips, countyFips, fields[3], classCode
                    ));
                }
            }
            return o;
        }
        public static IEnumerable<FipsRecord> GetCounties(State state) {
            List<FipsRecord> o = new List<FipsRecord>();
            foreach (FipsRecord r in Records)
                if (state.Equals(r.StatePostalCode))
                    o.Add(r);
            return o;
        }
        public static IEnumerable<FipsRecord> Search(
            string token, 
            SearchMethod searchMethod = SearchMethod.Default
        ) {
            List<FipsRecord> o = new List<FipsRecord>();
            if (
                String.IsNullOrWhiteSpace(token)
            ) throw new ArgumentNullException("token cannot be null or empty");

            foreach (FipsRecord r in Records) {
                // Check if exact match to state
                State state = State.Unknown;
                if (
                    searchMethod.HasFlag(SearchMethod.State) && 
                    Enum.TryParse(token.ToUpper(), out state) &&
                    state.Equals(r.StatePostalCode)
                ) {
                    o.Add(r);
                } else if (
                    searchMethod.HasFlag(SearchMethod.County) && 
                    r.CountyName.ToLower().Contains(token.ToLower())
                ) {
                    o.Add(r);
                }
            }
            return o;
        }
#endregion Methods
    }
}
