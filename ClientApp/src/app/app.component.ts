import { Component, OnDestroy, OnInit } from '@angular/core';
import {  Subject, takeUntil } from 'rxjs';
import { RouterModule } from '@angular/router';
import { LoadingBarComponent } from './shared/components/loading-bar/loading-bar.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  standalone: true,
  imports: [RouterModule, LoadingBarComponent ]
})
export class AppComponent implements OnInit, OnDestroy {
  title = 'Project Management';
  private destroy$ = new Subject<void>();

  constructor(
  ) {
  }
  ngOnInit() {
  }


  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
