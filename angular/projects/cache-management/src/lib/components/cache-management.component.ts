import { Component, OnInit } from '@angular/core';
import { CacheManagementService } from '../services/cache-management.service';

@Component({
  selector: 'lib-cache-management',
  template: ` <p>cache-management works!</p> `,
  styles: [],
})
export class CacheManagementComponent implements OnInit {
  constructor(private service: CacheManagementService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
