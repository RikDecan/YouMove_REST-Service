using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDL.Exceptions
{
public class MemberException : Exception
{
    public MemberException() : base() { }

    public MemberException(string message) : base(message) { }

    public MemberException(string message, Exception innerException) : base(message, innerException) { }
}

public class MemberNotFoundException : MemberException
{
    public int MemberId { get; }

    public MemberNotFoundException(int memberId) 
        : base($"Member with ID {memberId} was not found.") 
    {
        MemberId = memberId;
    }

    public MemberNotFoundException(int memberId, Exception innerException) 
        : base($"Member with ID {memberId} was not found.", innerException) 
    {
        MemberId = memberId;
    }
}
}
