import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DesignKitComponent } from './design-kit.component';

describe('DesignKitComponent', () => {
  let component: DesignKitComponent;
  let fixture: ComponentFixture<DesignKitComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DesignKitComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DesignKitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
