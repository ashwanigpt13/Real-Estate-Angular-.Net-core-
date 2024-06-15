  import { Component,OnInit } from '@angular/core';
  import { FormControl, FormGroup, Validators,AbstractControl, ValidationErrors, FormBuilder } from '@angular/forms';
  import { Router } from '@angular/router';
  import * as alertify from 'alertifyjs';
import { UserForRegister } from 'src/app/model/user';
import { AlertifyService } from 'src/app/services/alertify.service';
import { AuthService } from 'src/app/services/auth.service';
  @Component({
    selector: 'app-user-register',
    templateUrl: './user-register.component.html',
    styleUrls: ['./user-register.component.css']
  })
  export class UserRegisterComponent implements OnInit{
  userSubmitted!: boolean;
  registerationForm! : FormGroup;
  user!: UserForRegister;
  constructor(private fb: FormBuilder,
    private authService:AuthService, 
    private alertify: AlertifyService,
  private router: Router){}
  ngOnInit(){
    // this.registerationForm= new FormGroup({
    //   userName : new FormControl(null,[Validators.required]),
    //   email: new FormControl(null,[Validators.required,Validators.email]),
    //   password: new FormControl(null, [Validators.required,Validators.minLength(8)]),
    //   confirmPassword: new FormControl(null,Validators.required),
    //   mobile: new FormControl(null,[Validators.required,Validators.maxLength(10)])
    // },{ validators: this.passwordMatchingValidator });
    this.createRegistrationForm();
  }

  createRegistrationForm(){
    this.registerationForm = this.fb.group({
    userName:[null,Validators.required],
    email: [null,[Validators.required,Validators.email]],
    password:[null,[Validators.required,Validators.minLength(8)]],
    confirmPassword:[null,Validators.required],
    mobile:[null,[Validators.required,Validators.maxLength(10)]]
    } ,{validators: this.passwordMatchingValidator});
  }

  passwordMatchingValidator(control: AbstractControl): ValidationErrors | null {
    const password = control.get('password')?.value;
    const confirmPassword = control.get('confirmPassword')?.value;
    return password === confirmPassword ? null : { notmatched: true };
  }

  get userName(){
    return this.registerationForm.get('userName') as FormControl;
  }

  get email(){
    return this.registerationForm.get('email') as FormControl;
  }

  get password(){
    return this.registerationForm.get('password') as FormControl;
  }

  get confirmPassword(){
    return this.registerationForm.get('confirmPassword') as FormControl;
  }

  get mobile(){
    return this.registerationForm.get('mobile') as FormControl;
  }
  onSubmit(){
      this.userSubmitted=true;
      if(this.registerationForm.valid){
       console.log("register Submit",this.registerationForm);
      //this.user = Object.assign(this.user,this.registerationForm.value);
      this.authService.registerUser(this.userData()).subscribe(()=>
      {
        this.registerationForm.reset();
        this.alertify.success("You are successfully registered!")
        this.router.navigate(['/user/login']);
      });
      
     // this.router.navigate(['/user/user-login'])
      //this.userSubmitted=false;
      }
  }

  userData(): UserForRegister{
     return this.user={
      userName:this.userName.value,
      email:this.email.value,
      password:this.password.value,
      mobile:this.mobile.value


     }
  }

  
  }


