import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { User } from "../models/user";


@Injectable({
  providedIn: 'root',
 })
export class UserService {
    
  private users: User[] = [];
  
  constructor(private http: HttpClient) { }
    
      
  
    getUsers(): Observable<User[]> {
      return this.http.get<User[]>("api/users")
    }

    addUser(user: User): Observable<User> {
      return this.http.post<User>("api/user", user)
    }
  }