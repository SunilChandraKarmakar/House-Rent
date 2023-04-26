import { Injectable } from '@angular/core';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})

export class UserService {

  constructor() { }

  addUser(user: User): void {
    localStorage.setItem("_user", JSON.stringify(user));
  }
}
