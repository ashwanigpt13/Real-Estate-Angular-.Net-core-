import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserForLogin,UserForRegister } from '../model/user';
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  authUser(user:UserForLogin){
    return this.http.post('https://localhost:7272/api/Account/Login',user);
    //let UserArray: any[] = [];
    // const storedUsers = localStorage.getItem('Users');
    // if (storedUsers) {
    //   UserArray = JSON.parse(storedUsers);
    // }
    // return UserArray.find((p: any) => p.email === user.email && p.password === user.password);
  
}

registerUser(user: UserForRegister){
  return this.http.post('https://localhost:7272/api/Account/register',user)
}
   
}
