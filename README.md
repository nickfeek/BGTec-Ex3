### Ex3 Age Calculator (Website) ###

**Assumptions.**

1. Does not need to handle time zones
2. Does not process future birthdates


**Issues.**

1. The output includes hours, minutes and seconds. However, supplied birthdate is date only. Without a time component, conversion to DateTime sets time to midnight. Therefore, the hours, minutes and seconds of the result cannot be accurate. In test, the time of birth is included and the result tested, but in actual use, the time component reported will not be accurate (unless birthtime is midnight). 
2. Currently missing view tests. Function and pagemodel tests are in place. TODO


**Notes.**

None
