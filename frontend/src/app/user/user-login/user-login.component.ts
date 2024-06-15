
import { Component,OnInit } from '@angular/core';
import {FormBuilder, FormGroup, NgForm} from '@angular/forms';
import {AuthService} from 'src/app/services/auth.service'
import { AlertifyService } from 'src/app/services/alertify.service';
import { Router } from '@angular/router';
import { UserForLogin } from 'src/app/model/user';
@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent implements OnInit{

  constructor(private authService: AuthService,private alertify :AlertifyService,private router:Router){
  }
  
  ngOnInit(){
  }

  onLogin(loginForm:NgForm){
    console.log(loginForm.value);
   this.authService.authUser(loginForm.value).subscribe(
    response=>{
      console.log(response);
      const user: UserForLogin = response as UserForLogin; // Annotate the type of user
      localStorage.setItem('token', user.token);
      localStorage.setItem('userName', user.userName);
      this.alertify.success('Login Successful');
      this.router.navigate(['/']);
    }
   );
  
  // if(token){
  //   localStorage.setItem('token',token.userName);
  //   this.alertify.success('Login Succesful');
  //   this.router.navigate(['/']);
  // }
  // else{
  //   this.alertify.error('login not Successful');
  // }
  }
}
