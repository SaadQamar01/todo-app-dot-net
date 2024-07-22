import { Component, OnInit } from '@angular/core';
import { PaymentDetailFormComponent } from '../payment-detail-form/payment-detail-form.component';
import { PaymentDetailService } from '../shared/payment-detail.service';
import { CommonModule } from '@angular/common';
import { ToastrService } from 'ngx-toastr';
import { PaymentDetail } from '../shared/payment-detail.model';

@Component({
  selector: 'app-payment-details',
  standalone: true,
  imports: [PaymentDetailFormComponent,CommonModule],
  templateUrl: './payment-details.component.html',
  styleUrl: './payment-details.component.scss'
})
export class PaymentDetailsComponent implements OnInit{


  constructor(public service: PaymentDetailService, private toastr: ToastrService){

  }

  ngOnInit():void {
    this.service.refreshList()
  }

  populateForm(selectedRecord: PaymentDetail){
    this.service.formData = Object.assign({},selectedRecord);
  }

  onDelete(id:number){
    if(confirm('Are you sure you want to delete this record'))
      this.service.deletePaymentDetail(id).subscribe({
        next: res =>{
          console.log(res);
          this.service.list = res as PaymentDetail[]
          this.toastr.error("Deleted succesfully","Payment Detail Register")
        },
        error: err => {console.log(err)}
      })
  
  }
}
