import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MenuEditItemComponent } from './menu-edit-item.component';

describe('MenuEditItemComponent', () => {
  let component: MenuEditItemComponent;
  let fixture: ComponentFixture<MenuEditItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MenuEditItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MenuEditItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
