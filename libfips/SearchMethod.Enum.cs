using System;

namespace libfips {
    [Flags]
    public enum SearchMethod {
        Default = StateAndCounty, 
        State = 1 << 0, 
        County = 1 << 1, 
        StateAndCounty = State | County
    }
}
