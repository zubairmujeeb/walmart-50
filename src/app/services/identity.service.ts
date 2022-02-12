import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class IdentityService {

  constructor(private http: HttpClient) { }

  signUp(data){
    return this.http.post('http://localhost:44366/api/identity/register',data)
  }

  getProfile(email){
    return this.http.post(`http://localhost:44366/api/identity/getprofile/`,{email:email})

  }
}
