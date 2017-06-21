namespace libfips {
    using System;
    /// <summary>
    /// 
    /// </summary>
    public struct FipsRecord {
        /// <summary>
        /// 
        /// </summary>
        public State StatePostalCode { get; }
        /// <summary>
        /// 
        /// </summary>
        public int StateFipsCode { get; }
        /// <summary>
        /// 
        /// </summary>
        public int CountyFipsCode { get; }
        /// <summary>
        /// 
        /// </summary>
        public string FipsCode {
            get {
                return String.Format(
                    "{0:D2}-{1:D3}", StateFipsCode, CountyFipsCode
                );
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CountyName { get; }
        /// <summary>
        /// 
        /// </summary>
        public FipsClassCode ClassCode { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="statePostalCode"></param>
        /// <param name="stateFipsCode"></param>
        /// <param name="countyFipsCode"></param>
        /// <param name="countyName"></param>
        /// <param name="classCode"></param>
        public FipsRecord(
            State statePostalCode = State.Unknown, 
            int stateFipsCode = (int)State.Unknown, 
            int countyFipsCode = 0, 
            string countyName = default(string), 
            FipsClassCode classCode = FipsClassCode.Unknown
        ) {
            StatePostalCode = statePostalCode;
            StateFipsCode = stateFipsCode;
            CountyFipsCode = countyFipsCode;
            CountyName = countyName;
            ClassCode = classCode;
        }
    }
}
