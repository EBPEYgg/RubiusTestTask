const BASE_URL = "http://localhost:5012/api/v1/music";

export const getAllMusicians = async (): Promise<Musician[]> => {
  const response = await fetch(`${BASE_URL}/tree`);
  return response.json();
};

export const markTrackAsListened = async (trackId: number): Promise<any> => {
  const response = await fetch(`${BASE_URL}/listened/${trackId}`, { method: 'POST' });
};

export const rateTrack = async (trackId: number, rating: number): Promise<any> => {
  const response = await fetch(`${BASE_URL}/rate/${trackId}?rating=${rating}`, { method: 'POST' });
};

export const addTrackToFavorites = async (trackId: number): Promise<any> => {
  const response = await fetch(`${BASE_URL}/favorite/${trackId}`, { method: 'POST' });
};