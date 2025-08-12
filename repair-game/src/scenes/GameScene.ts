import Phaser from 'phaser'

export default class GameScene extends Phaser.Scene {
  private partsPlacedCount: number = 0
  private totalParts: number = 3
  private progressBarGraphics!: Phaser.GameObjects.Graphics
  private progressText!: Phaser.GameObjects.Text

  constructor() {
    super('GameScene')
  }

  create() {
    const gameWidth = this.scale.width
    const gameHeight = this.scale.height

    // Background
    this.add.rectangle(gameWidth / 2, gameHeight / 2, gameWidth, gameHeight, 0x1f1f1f)

    // Device drop zone (the thing we are repairing)
    const zoneWidth = 260
    const zoneHeight = 340
    const zoneX = gameWidth * 0.65
    const zoneY = gameHeight * 0.5

    const deviceZone = this.add
      .zone(zoneX, zoneY, zoneWidth, zoneHeight)
      .setRectangleDropZone(zoneWidth, zoneHeight)

    // Visual outline for the drop zone
    const outline = this.add.graphics()
    outline.lineStyle(4, 0x4caf50, 1)
    outline.strokeRect(zoneX - zoneWidth / 2, zoneY - zoneHeight / 2, zoneWidth, zoneHeight)

    this.add.text(zoneX, zoneY - zoneHeight / 2 - 28, 'Broken Device', {
      fontSize: '18px',
      color: '#a5d6a7',
    }).setOrigin(0.5)

    // Slots inside the device where parts snap into
    const slotPositions = [
      new Phaser.Math.Vector2(zoneX - 60, zoneY - 80),
      new Phaser.Math.Vector2(zoneX + 40, zoneY),
      new Phaser.Math.Vector2(zoneX - 20, zoneY + 90),
    ]

    slotPositions.forEach((pos) => {
      const slot = this.add.rectangle(pos.x, pos.y, 80, 40, 0x2e7d32, 0.25)
      slot.setStrokeStyle(2, 0x81c784, 0.9)
    })

    // Parts to drag from the left
    const partSpecs = [
      { color: 0xff8a65, label: 'Fuse' },
      { color: 0x4fc3f7, label: 'Gear' },
      { color: 0xfff176, label: 'Wire' },
    ]

    const startX = gameWidth * 0.25
    const startYs = [gameHeight * 0.25, gameHeight * 0.5, gameHeight * 0.75]

    const parts: Phaser.GameObjects.Rectangle[] = []

    partSpecs.forEach((spec, index) => {
      const part = this.add.rectangle(startX, startYs[index], 120, 50, spec.color)
      part.setStrokeStyle(3, 0xffffff, 0.7)
      part.setData('label', spec.label)
      part.setData('homeX', part.x)
      part.setData('homeY', part.y)
      part.setData('placed', false)

      const text = this.add.text(part.x, part.y, spec.label, {
        fontSize: '16px',
        color: '#000000',
      }).setOrigin(0.5)

      // Bind the text to move with the part
      this.events.on('update', () => {
        text.setPosition(part.x, part.y)
      })

      part.setInteractive({ draggable: true, cursor: 'grab' })
      this.input.setDraggable(part)

      parts.push(part)
    })

    // Drag behaviors
    this.input.on('dragstart', (_pointer: Phaser.Input.Pointer, gameObject: Phaser.GameObjects.GameObject) => {
      this.children.bringToTop(gameObject)
    })

    this.input.on('drag', (_pointer: Phaser.Input.Pointer, gameObject: Phaser.GameObjects.GameObject, dragX: number, dragY: number) => {
      const rect = gameObject as Phaser.GameObjects.Rectangle
      if (rect.getData('placed')) return
      rect.setPosition(dragX, dragY)
    })

    this.input.on('drop', (_pointer: Phaser.Input.Pointer, gameObject: Phaser.GameObjects.GameObject, dropZone: any) => {
      const rect = gameObject as Phaser.GameObjects.Rectangle
      if (rect.getData('placed')) return

      if (dropZone === deviceZone) {
        // Snap to the first available slot
        const nextIndex = this.partsPlacedCount
        if (nextIndex < slotPositions.length) {
          const target = slotPositions[nextIndex]
          rect.setPosition(target.x, target.y)
          rect.setData('placed', true)
          this.partsPlacedCount += 1
          this.updateProgressBar()

          // Little success flash
          this.tweens.add({
            targets: rect,
            alpha: { from: 0.6, to: 1 },
            duration: 180,
            yoyo: true,
          })

          if (this.partsPlacedCount === this.totalParts) {
            this.onRepairComplete()
          }
        }
      }
    })

    this.input.on('dragend', (_pointer: Phaser.Input.Pointer, gameObject: Phaser.GameObjects.GameObject, dropped: boolean) => {
      const rect = gameObject as Phaser.GameObjects.Rectangle
      if (rect.getData('placed')) return
      if (!dropped) {
        rect.setPosition(rect.getData('homeX'), rect.getData('homeY'))
      }
    })

    // Instructions
    this.add.text(startX, 36, 'Drag parts into the device to repair it', {
      fontSize: '18px',
      color: '#ffffff',
    }).setOrigin(0.5, 0)

    // Progress bar UI
    this.progressBarGraphics = this.add.graphics()
    this.progressText = this.add.text(gameWidth / 2, 4, 'Repair: 0%', {
      fontSize: '16px',
      color: '#ffffff',
    }).setOrigin(0.5, 0)

    this.updateProgressBar()
  }

  private updateProgressBar() {
    const width = this.scale.width * 0.6
    const height = 18
    const x = (this.scale.width - width) / 2
    const y = 28

    const progress = Phaser.Math.Clamp(this.partsPlacedCount / this.totalParts, 0, 1)

    this.progressBarGraphics.clear()

    // Background
    this.progressBarGraphics.fillStyle(0x424242, 1)
    this.progressBarGraphics.fillRoundedRect(x, y, width, height, 8)

    // Fill
    this.progressBarGraphics.fillStyle(0x81c784, 1)
    this.progressBarGraphics.fillRoundedRect(x + 2, y + 2, (width - 4) * progress, height - 4, 6)

    this.progressText.setText(`Repair: ${Math.round(progress * 100)}%`)
  }

  private onRepairComplete() {
    const message = this.add.text(this.scale.width / 2, this.scale.height - 40, 'Device Repaired! ✔', {
      fontSize: '24px',
      color: '#a5d6a7',
    }).setOrigin(0.5)

    this.tweens.add({
      targets: message,
      y: this.scale.height - 64,
      duration: 400,
      ease: 'Sine.easeOut',
    })

    // Celebrate with a brief tint on the drop zone outline
    const flash = this.add.rectangle(this.scale.width * 0.65, this.scale.height * 0.5, 260, 340, 0x4caf50, 0.1)
    this.tweens.add({ targets: flash, alpha: 0, duration: 600 })
  }
}