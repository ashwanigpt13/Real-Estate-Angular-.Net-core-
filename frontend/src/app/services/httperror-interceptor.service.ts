import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Observable, catchError, retryWhen } from "rxjs";
import { AlertifyService } from "./alertify.service";
import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class HttpErrorInterceptorService implements HttpInterceptor{
   
   constructor(private alertify: AlertifyService){

   }
   
   intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    console.log('Http req started');
    return next.handle(request).
    pipe(
        
        catchError((error: HttpErrorResponse) => {
            const errorMessage=this.setError(error);
            console.log(error);
            this.alertify.error(error.error["errorMessage"]);
            throw new Error(error.error["errorMessage"]);
        })
    );
}

setError(error: HttpErrorResponse): string {
    let errorMessage = 'Unknown error occured';
    if(error.error instanceof ErrorEvent) {
        // Client side error
        errorMessage = error.error.message;
    } else {
        // server side error
        if(error.status===401)
        {
            return error.statusText;
        }

        if (error.error.errorMessage && error.status!==0) {
            {errorMessage = error.error.errorMessage;}
        }

        if (!error.error.errorMessage && error.error && error.status!==0) {
            {errorMessage = error.error;}
        }
    }
    return errorMessage;
}

}