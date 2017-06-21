namespace libfips {
    using System;
    using System.ComponentModel;

    /// <summary>
    /// FIPS Class Codes provide additional metadata regarding the geographic location
    /// </summary>
    [Flags]
    public enum FipsClassCode {
        /// <summary>
        /// Unknown FIPS Class Code
        /// </summary>
        [Description("Unknown FIPS Class Code")]
        Unknown = 0, 
        /// <summary>
        /// identifies an active county or statistically equivalent entity that does not qualify under subclass C7 or H6
        /// </summary>
        [Description("Active County/Entity")]
        H1 = 1 << 0, 
        /// <summary>
        /// identifies a legally defined inactive or nonfunctioning county or statistically equivalent entity that does not qualify under subclass H6
        /// </summary>
        [Description("Legally Defined Inactive/Nonfunctioning County/Entity")]
        H4 = 1 << 1,
        /// <summary>
        /// identifies census areas in Alaska, a statistical county equivalent entity
        /// </summary>
        [Description("Alaskan Census Area")]
        H5 = 1 << 2,
        /// <summary>
        /// identifies a county or statistically equivalent entity that is areally coextensive or governmentally consolidated with an incorporated place, part of an incorporated place, or a consolidated city
        /// </summary>
        [Description("Areally Coextensive/Governmentally Consolidated/Incorporated Entity")]
        H6 = 1 << 3,
        /// <summary>
        /// identifies an incorporated place that is an independent city; that is, it also serves as a county equivalent because it is not part of any county, and a minor civil division (MCD) equivalent because it is not part of any MCD
        /// </summary>
        [Description("Independent City/County Equivalent")]
        C7 = 1 << 4
    }
}
