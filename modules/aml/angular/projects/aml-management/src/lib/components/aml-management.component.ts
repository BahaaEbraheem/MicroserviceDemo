import { Component, OnInit } from '@angular/core';
import { AmlManagementService } from '../services/aml-management.service';

@Component({
  selector: 'lib-aml-management',
  template: ` <p>aml-management works!</p> `,
  styles: [],
})
export class AmlManagementComponent implements OnInit {
  constructor(private service: AmlManagementService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
