import './style.css'
import Phaser from 'phaser'
import GameScene from './scenes/GameScene'

const config: Phaser.Types.Core.GameConfig = {
  type: Phaser.AUTO,
  width: 800,
  height: 600,
  backgroundColor: '#1f1f1f',
  parent: 'app',
  scene: [GameScene],
  physics: {
    default: 'arcade',
    arcade: { debug: false },
  },
}

// eslint-disable-next-line @typescript-eslint/no-unused-vars
const game = new Phaser.Game(config)
