import { Component, OnInit } from '@angular/core';
import { NzUploadChangeParam } from 'ng-zorro-antd/upload';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { CityGridModel, CityModel, CountryGridModel, PropertyModel, UserModel } from 'src/app/models/api.model';
import { CityService } from 'src/app/services/city.service';
import { CountryService } from 'src/app/services/country.service';
import { PropertyService } from 'src/app/services/property.service';
import { FurnishingType, PropertyAddTab, PropertyType } from 'src/app/utility/system-enum-collection.enum';

@Component({
  selector: 'app-add-property',
  templateUrl: './add-property.component.html',
  styleUrls: ['./add-property.component.scss']
})

export class AddPropertyComponent implements OnInit {

  // Set true or false value in html
  true: boolean = true;
  false: boolean = false;

  // Property model
  propertyModel: PropertyModel = new PropertyModel(); 

  // City list model
  cities: CityGridModel[] = [];
  cascadingCities: CityModel[] = [];

  // country list model
  countries: CountryGridModel[] = [];

  // Selected tab index
  nzSelectedTabIndex: number = 0;

  // Property preview
  cityName: string | undefined;
  propertyTypeName: string | undefined;
  furnishingTypeName: string | undefined;

  constructor(private cityService: CityService, private countryService: CountryService, 
    private spinnerService: NgxSpinnerService, private toastrService: ToastrService, 
    private propertyService: PropertyService) { }

  ngOnInit() {
    // Get cities
    this.getCities();

    // Get countries
    this.getCountries();
  }

  // Get cities
  private getCities(): void {
    this.spinnerService.show();
    this.cityService.getAll().subscribe((cities: CityGridModel[]) => {
      this.cities = cities;
      this.spinnerService.hide();
    },
    (error: any) => {
      this.spinnerService.hide();
      this.toastrService.error(error, "Error");
    });
  }

  // Get countries
  private getCountries(): void {
    this.spinnerService.show();
    this.countryService.getAll().subscribe((countries: CountryGridModel[]) => {
      this.countries = countries;
      this.spinnerService.hide();
    },
    (error: any) => {
      this.spinnerService.hide();
      this.toastrService.error(error, "Error");
    });
  }

  // Basci information tab validation
  private basicInfoTabValidation(): boolean {
    if(this.propertyModel.name == undefined || this.propertyModel.name == null) {
      this.toastrService.warning("Please, provied your project name.", "Warning");
      return false;
    }
    else if(this.propertyModel.sellRent == undefined || this.propertyModel.sellRent == null) {
      this.toastrService.warning("Please, select sell or rent.", "Warning");
      return false;
    }
    else if(this.propertyModel.bhk == undefined || this.propertyModel.bhk == null) {
      this.toastrService.warning("Please, select bhk.", "Warning");
      return false;
    }
    else if(this.propertyModel.propertyTypeId == undefined || this.propertyModel.propertyTypeId == null) {
      this.toastrService.warning("Please, select property type.", "Warning");
      return false;
    }
    else if(this.propertyModel.furnishingTypeId == undefined || this.propertyModel.furnishingTypeId == null) {
      this.toastrService.warning("Please, select furnishing type.", "Warning");
      return false;
    } 
    else {
      return true;
    }   
  }

  // Price area tab validation
  private priceAreaTabValidation(): boolean {
    if(this.propertyModel.price == undefined || this.propertyModel.price == null) {
      this.toastrService.warning("Please, provied price.", "Warning");
      return false;
    }
    else if(this.propertyModel.buildArea == undefined || this.propertyModel.buildArea == null) {
      this.toastrService.warning("Please, provied build area.", "Warning");
      return false;
    }
    else if(this.propertyModel.carpetArea == undefined || this.propertyModel.carpetArea == null) {
      this.toastrService.warning("Please, provied carpet area.", "Warning");
      return false;
    }
    else if(this.propertyModel.furnishingTypeId == undefined || this.propertyModel.furnishingTypeId == null) {
      this.toastrService.warning("Please, select furnishing type.", "Warning");
      return false;
    } 
    else {
      return true;
    }  
  }

  // Address information tab validation
  private addressInfoTabValidation(): boolean {
    if(this.propertyModel.floorNo == undefined || this.propertyModel.floorNo == null) {
      this.toastrService.warning("Please, provied floor no.", "Warning");
      return false;
    }
    else if(this.propertyModel.totalFloor == undefined || this.propertyModel.totalFloor == null) {
      this.toastrService.warning("Please, provied total floor.", "Warning");
      return false;
    }
    else if(this.propertyModel.address.addressLineOne == undefined || this.propertyModel.carpetArea == null 
      || this.propertyModel.address.addressLineOne == "") {
      this.toastrService.warning("Please, provied address line one.", "Warning");
      return false;
    }
    else if(this.propertyModel.address.cityId == undefined || this.propertyModel.address.cityId == null) {
      this.toastrService.warning("Please, select city.", "Warning");
      return false;
    } 
    else if(this.propertyModel.address.countryId == undefined || this.propertyModel.address.countryId == null) {
      this.toastrService.warning("Please, select country.", "Warning");
      return false;
    } 
    else {
      return true;
    }  
  }

  // Other details tab validation
  private otherDetailsTabValidation(): boolean {
    if(this.propertyModel.isReadyToMove == undefined || this.propertyModel.isReadyToMove == null) {
      this.toastrService.warning("Please, select ready or not.", "Warning");
      return false;
    }
    else if(this.propertyModel.isGated == undefined || this.propertyModel.isGated == null) {
      this.toastrService.warning("Please, select gated community.", "Warning");
      return false;
    }
    else if(this.propertyModel.estPossessionOn == undefined || this.propertyModel.estPossessionOn == null) {
      this.toastrService.warning("Please, select possession/avaialble from.", "Warning");
      return false;
    }
    else {      
      let readyToMove: any = this.propertyModel.isReadyToMove;
      let isGated: any = this.propertyModel.isGated;

      this.propertyModel.isReadyToMove = readyToMove == "true" ? true : false;
      this.propertyModel.isGated = isGated == "true" ? true : false;
      return true;
    }  
  }

  // Working with photo controller
  handleChange({ file, fileList }: NzUploadChangeParam): void {
    const status = file.status;
    
    if (status === 'done') {
      console.log("Done");
      console.log("File List :- ", fileList);
    } 
  }

  // Goto pricing area tab
  onGoPricingAreaTab(tabIndex: number): void {
    if(this.nzSelectedTabIndex == PropertyAddTab.BasicInformation) {
      let isBasicInfoTabValidate: boolean = this.basicInfoTabValidation();
      if(isBasicInfoTabValidate) {
        this.nzSelectedTabIndex += tabIndex;
      }
    }
  }

  // Goto address information tab
  onGoAddressInformationTab(tabIndex: number): void {
    if(this.nzSelectedTabIndex == PropertyAddTab.PricingArea) {
      let isPriceAreaTabValidate: boolean = this.priceAreaTabValidation();
      if(isPriceAreaTabValidate) {
        this.nzSelectedTabIndex += tabIndex;
      }
    }
  }

  // Goto other details tab
  onGoOtherDetailsTab(tabIndex: number): void {
    if(this.nzSelectedTabIndex == PropertyAddTab.AddressInformation) {
      let isAddressInfoTabValidate: boolean = this.addressInfoTabValidation();
      if(isAddressInfoTabValidate) {
        this.nzSelectedTabIndex += tabIndex;
      }
    }
  }

  // Goto photo tab
  onGoPhotoTab(tabIndex: number): void {
    if(this.nzSelectedTabIndex == PropertyAddTab.OtherDetails) {
      let isOtherDetailsTabValidate: boolean = this.otherDetailsTabValidation();
      if(isOtherDetailsTabValidate) {
        this.nzSelectedTabIndex += tabIndex;
      }
    }
  }
  
  // Go back tab
  onGoBackTab(tabIndex: number): void {
    this.nzSelectedTabIndex -= tabIndex;
  }

  // Get tab index when tab is change
  indexChange(event: any): void {
    this.nzSelectedTabIndex = event;
  }

  // Get current user id
  private getCurrentUserId(): string | undefined {
    let loginUserInfo: UserModel = JSON.parse(localStorage.getItem("_loginUserInfo")!);
    let userId: string | undefined;

    if(loginUserInfo != null || loginUserInfo != undefined) {
      userId = loginUserInfo.id;
    }

    return userId;
  }

  // Cascading city based on country
  onChangeCountry(event: any): void {
    this.cascadingCities = this.cities.filter((x: CityGridModel) => x.countryId == event);
  }

  // Get property type name name based on selected property type id
  onPropertyTypeModelChange(event: any): void {
    let selectedValue: number = +event;

    switch(selectedValue) {
      case 1:
        this.propertyTypeName = PropertyType[PropertyType.House];
        break;
      case 2:
        this.propertyTypeName = PropertyType[PropertyType.Apartment];
        break;
      default:
        this.propertyTypeName = PropertyType[PropertyType.Duplex];
        break;
    }
  }

  // Get furnishing type name name based on selected furnishing type id
  onFurnishingTypeModelChange(event: any): void {
    let selectedValue: number = +event;

    switch(selectedValue) {
      case 1:
        this.furnishingTypeName = FurnishingType[FurnishingType.Fully];
        break;
      case 2:
        this.furnishingTypeName = FurnishingType[FurnishingType.Semi];
        break;
      default:
        this.furnishingTypeName = FurnishingType[FurnishingType.Unfurnished];
        break;
    }
  }

  // Get city name based on selecte city id
  onCityModelChange(event: any): void {
    this.cityName = this.cascadingCities.find((x: CityModel) => x.id == event)?.name;
  }

  submitForm(): void {
    this.propertyModel.userId = this.getCurrentUserId()!;

    this.spinnerService.show();
    this.propertyService.upsert(this.propertyModel).subscribe(() => {
      this.spinnerService.hide();
      this.toastrService.success("Property saved.", "Successfull");
    });
  }
}