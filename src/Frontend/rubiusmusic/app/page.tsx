"use client";

import { useEffect, useState } from "react";
import { Button, Layout, Modal, Space, Collapse, List } from "antd";
import { getAllMusicians, rateTrack } from "./services/musicians";


const { Content } = Layout;

export default function MusiciansPage() {
  const [musicians, setMusicians] = useState<Musician[]>([]);
  const [selectedTracks, setSelectedTracks] = useState<Track[]>([]);
  const [modalVisible, setModalVisible] = useState<boolean>(false);
  const [trackStates, setTrackStates] = useState<Record<number, number>>({});

  useEffect(() => {
    const getMusicians = async () => {
      const data = await getAllMusicians();
      setMusicians(data);

      const initialStates: Record<number, number> = {};
        data.forEach((musician) =>
          musician.albums.forEach((album) =>
            album.tracks.forEach((track) => {
              initialStates[track.id] = track.rating;
            })
          )
        );
        setTrackStates(initialStates);
    };

    getMusicians();
  }, []);

  const openAlbumModal = (tracks: Track[]) => {
    setSelectedTracks(tracks);
    setModalVisible(true);
  };

  const closeModal = () => {
    setModalVisible(false);
    setSelectedTracks([]);
  };

  const toggleRating = async (trackId: number) => {
    const currentRating = trackStates[trackId] || 0;
    const newRating = currentRating === 1 ? -1 : 1;

    await rateTrack(trackId, newRating);

    setTrackStates((prev) => ({
      ...prev,
      [trackId]: newRating
    }));
  };

  const getRatingButtonStyle = (rating: number) => {
    if (rating === 1) {
      return { backgroundColor: "#b3d4fc", color: "#000" };
    } else if (rating === -1) {
      return { backgroundColor: "#ffcccc", color: "#000" };
    } else {
      return {};
    }
  };

  const getRatingButtonText = (rating: number) => {
    return rating === 1 ? "Нравится" : rating === -1 ? "Не нравится" : "Нравится";
  };

  const musicianItems = musicians.map((musician) => ({
    key: musician.id.toString(),
    label: musician.name,
    children: (
      <Space direction="vertical" style={{ width: "100%" }}>
        {musician.albums && musician.albums.length > 0 ? (
          musician.albums.map((album) => (
            <Button key={album.id} type="default" block onClick={() => openAlbumModal(album.tracks)}>
              {album.name}, {album.releaseYear}
            </Button>
          ))
        ) : (
          <p>Альбомы отсутствуют</p>
        )}
      </Space>
    ),
  }));

  return (
    <Layout>
      <Content style={{ padding: "20px" }}>
        <h1>Исполнители</h1>
          <Collapse accordion items={musicianItems} style={{ marginTop: "10px", width: "30%" }} />
        <Modal title="Треки альбома" open={modalVisible} onCancel={closeModal} footer={null}>
          <List
            dataSource={selectedTracks}
            renderItem={(track) => (
              <List.Item>
                <List.Item.Meta
                  title={track.name}
                  description={`Длительность: ${track.duration}`}
                />
                <div style={{ display: "flex", flexDirection: "column", gap: "8px" }}>
                  <div style={{ display: "flex", gap: "8px" }}>
                    <Button
                      style={getRatingButtonStyle(trackStates[track.id])}
                      onClick={() => toggleRating(track.id)}
                    >
                      {getRatingButtonText(trackStates[track.id])}
                    </Button>
                  </div>
                  <div style={{ display: "flex", gap: "8px" }}>
                    <Button
                      style={{ backgroundColor: track.isListened ? "#b3d4fc" : undefined }}
                    >
                      Прослушано
                    </Button>
                    <Button
                      style={{ backgroundColor: track.isFavorite ? "#b3d4fc" : undefined }}
                    >
                      В избранное
                    </Button>
                  </div>
                </div>
              </List.Item>
            )}
          />
        </Modal>
      </Content>
    </Layout>
  );
}