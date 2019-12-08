import { Injectable } from '@angular/core';
declare let alertify:any
@Injectable({
  providedIn: 'root'
})
export class AlertifyService {

constructor() { }

error(message:string){
  alertify.error(message)
  
}
success(message:string){
  alertify.success(message)
  
}
warning(message:string){
  alertify.warning(message)
  
}
confirm(message: string, okCallback: () => any) {
  alertify.confirm(message, function (e: any) {
    if (e) {
      okCallback();
    } else { }
  });
}

}
