export class loginrequest
{
   Email:string;
   Password:string;
}

export class loginResponse
{
    Token:string;
    RoleID:number;
    UserID:number;
    name:string;
}

export class ForgotPassword
{
    EmailId:string;
}

export class ChangePassword
{
    currentpassword:string;
    newpassword:string;
    confirmpassword:string;
    userid:string

}

export class ResponsefromApi
{
     ResponseCode:any

    ResponseInfo:any
}