import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NarudzbaLijekovaComponent } from './narudzba-lijekova.component';

describe('NarudzbaLijekovaComponent', () => {
  let component: NarudzbaLijekovaComponent;
  let fixture: ComponentFixture<NarudzbaLijekovaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NarudzbaLijekovaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NarudzbaLijekovaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
