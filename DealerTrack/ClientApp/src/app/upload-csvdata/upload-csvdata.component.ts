import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-upload-csvdata',
  templateUrl: './upload-csvdata.component.html'
})
export class UploadCsvdataComponent {
  public vechicleSold: VechicleSold[];
  public mostOftenVechicleSold: VechicleSold[];
  public isFileSelected: boolean = false;
  selectedFile: File =  null;
  url: string = null;
    
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl;
    console.log(this.url );
  }

  onFileSelected(event) {
    console.log(event)
    this.selectedFile = <File> event.target.files[0];
    const fd = new FormData();
    fd.append('file', this.selectedFile, this.selectedFile.name);
    console.log(fd);
    this.http.post(this.url + 'api/VechicleSold/FileUpload', fd)
      .subscribe(result => {
        this.isFileSelected = true;
        console.log(result);

      }, error => {
        console.error(error)
        this.isFileSelected = false;
      });
  }
  onUpload() {

    this.http.get<VechicleSold[]>(this.url + 'api/VechicleSold/GetAllVechicleSoldInformation').subscribe(result => {
      this.vechicleSold = result;
      console.log(result);

      this.http.get<VechicleSold[]>(this.url + 'api/VechicleSold/MostOftenVechicleSoldInfo').subscribe(result => {
        this.mostOftenVechicleSold = result;
        console.log(result);
      }, error => console.error(error));

    }, error => console.error(error));
  }



}
//MostOftenVechicleSoldInfo

interface VechicleSold {
  customerName: string;
  date: Date;
  dealNumber: number;
  dealershipName: string;
  price: number;
  vehicle: string;
  
  
}
