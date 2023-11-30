import { render, screen } from '@testing-library/react';
import City from './City';

describe('City component', () => {
  const city = {
    city: 'New York',
    temperature: 25,
    conditions: 'Sunny',
    guid: '1234',
  };

  it('renders city name', async () => {
    render(<City city={city} />);

    const item = await screen.getByText(city.city);

    expect(item).not.toBeNull();
  });

  it('renders temperature', async () => {
    render(<City city={city} />);

    const item = await screen.getByText(city.temperature);

    expect(item).not.toBeNull();
  });

  it('renders conditions', async () => {
    render(<City city={city} />);

    const item = await screen.getByText(city.conditions);

    expect(item).not.toBeNull();
  });
});
