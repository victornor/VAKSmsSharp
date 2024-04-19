using VakSMSSharp.Entities;
using VakSMSSharp.Enums;

namespace VakSMSSharp.Abstractions;

public interface IVakSmsService
{
    Task<float> GetBalanceAsync();
    Task<Phone> GetPhoneAsync(PhoneCountry country, PhoneService service);
    Task<PhoneStatus> SetStatusAsync(Phone phone, PhoneUpdateStatus status);
    Task<string?> GetSmsAsync(Phone phone);
}