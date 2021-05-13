import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProdajaComponent } from './prodaja.component';

describe('ProdajaComponent', () => {
  let component: ProdajaComponent;
  let fixture: ComponentFixture<ProdajaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProdajaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProdajaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
