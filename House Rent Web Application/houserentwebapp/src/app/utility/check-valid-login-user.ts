import { NgxSpinnerService } from "ngx-spinner";
import { UserModel } from "../models/api.model";
import { ActivatedRoute } from "@angular/router";
import { ToastrService } from "ngx-toastr";

export class CheckValidLoginUser {

    constructor(private spinnerService: NgxSpinnerService, toastrService: ToastrService, 
    private activatedRoute: ActivatedRoute) {

    }
    
    public static isLoginUser(): void {
        let loginUserInfo: UserModel = JSON.parse(localStorage.getItem("_loginUserInfo")!);

        if(loginUserInfo == null || loginUserInfo == undefined) {
            this.t
        }
        else {
            return true;
        }
    }
}