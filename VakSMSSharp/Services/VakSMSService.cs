using VakSMSSharp.Abstractions;
using VakSMSSharp.Entities;
using VakSMSSharp.Enums;
using VakSMSSharp.Responses;
using VakSMSSharp.Utils;

namespace VakSMSSharp.Services;

public class VakSMSService : BaseApiService, IVakSmsService
{
    public VakSMSService(string apiKey) : base(apiKey)
    {
    }

    public async Task<float> GetBalanceAsync()
    {
        var response = await ExecuteRequestAsync<BalanceResponse>("https://vak-sms.com/api/getBalance", HttpMethod.Get);
        return response.Balance;
    }

    public async Task<Phone> GetPhoneAsync(PhoneCountry country, PhoneService service)
    {
        var countryCode = CountryLookupUtility.GetCountryAPICode(country);
        var serviceCode = ServiceLookupUtility.GetServiceAPICode(service);
        
        var response = await ExecuteRequestAsync<Phone>($"https://vak-sms.com/api/getNumber?country={countryCode}&service={serviceCode}", HttpMethod.Get);
        return response;
    }

    public async Task<PhoneStatus> SetStatusAsync(Phone phone, PhoneUpdateStatus status)
    {
        var response =
            await ExecuteRequestAsync<StatusResponse>(
                $"https://vak-sms.com/api/setStatus?number={phone.Number}&status={status}&idNum={phone.Id}", HttpMethod.Get);
        
        return response.Status;
    }

    public async Task<string?> GetSmsAsync(Phone phone)
    {
        var response =
            await ExecuteRequestAsync<GetSmsResponse>(
                $"https://vak-sms.com/api/getSmsCode?idNum={phone.Id}", HttpMethod.Get);

        return response.SmsCode;
    }
}