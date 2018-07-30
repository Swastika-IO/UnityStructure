

public class MyApi  {

    public const string HOST = "http://ostar.vtdvn.net";
    public const string USER_REQUEST_LOGIN = HOST + "/samsung/user/login";
    public const string API_GET_CONFIG = HOST + "/api/milo/v3/lang/config";
    public const string USER_REQUEST_REGISTER = HOST + "/samsung/user/register";
    public const string API_GET_PROVINCE = HOST + "/api/user/list_province";
    public const string API_POST_LOGIN = HOST + "/api/auth/login";
    /**
     * {0} : user id 
     **/
    public const string LOCATION_REQUEST = HOST + "/samsung/{0}/locations";
}
