using System.Collections.Generic;
using SampleBank.WebAPI.Models;

namespace SampleBank.WebAPI.Data
{
    public class ReferenceDataList
    {
        public static List<DropdownValue> gender = new List<DropdownValue>() {
            new DropdownValue {Id =1, Name="Male", Code="Male"},
            new DropdownValue {Id =2, Name="Female", Code="Female"}
        };

        public static List<DropdownValue> accountTypes = new List<DropdownValue>() {
            new DropdownValue {Id =1, Name="Saving", Code="Male"},
            new DropdownValue {Id =2, Name="Current", Code="Female"}
        };
    }
}
