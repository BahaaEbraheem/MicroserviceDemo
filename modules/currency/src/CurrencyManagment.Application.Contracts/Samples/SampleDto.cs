using System.Runtime.Serialization;

namespace CurrencyManagment.Samples;
[DataContract]

public class SampleDto
{
    [DataMember(Order = 1)]

    public int Value { get; set; }
}
