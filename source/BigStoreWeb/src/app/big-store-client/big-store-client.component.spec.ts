import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BigStoreClientComponent } from './big-store-client.component';

describe('BigStoreClientComponent', () => {
  let component: BigStoreClientComponent;
  let fixture: ComponentFixture<BigStoreClientComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BigStoreClientComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BigStoreClientComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
