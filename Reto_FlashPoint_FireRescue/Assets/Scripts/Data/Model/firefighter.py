import json
import random
import time

def move_position(current_pos):
    # Randomly choose a direction: up, down, left, or right
    direction = random.choice(['up', 'down', 'left', 'right'])

    if direction == 'up' and current_pos['z'] < 6:
        current_pos['z'] += 1
    elif direction == 'down' and current_pos['z'] > 1:
        current_pos['z'] -= 1
    elif direction == 'left' and current_pos['x'] > 1:
        current_pos['x'] -= 1
    elif direction == 'right' and current_pos['x'] < 8:
        current_pos['x'] += 1

    return current_pos

def generate_random_positions(num_firefighters, initial_positions=None):
    firefighters = []
    for i in range(1, num_firefighters + 1):
        if initial_positions:
            # Move from current position
            new_position = move_position(initial_positions[i-1])
        else:
            # Generate new random position if no initial position is provided
            new_position = {
                "x": random.randint(1, 8),
                "y": 0,
                "z": random.randint(1, 6)
            }
        
        firefighter = {
            "id": i,
            "actionPoints": 4,
            "victim": 0,
            "knockOut": 0,
            "carryingVictim": False,
            "position": new_position
        }
        firefighters.append(firefighter)

    data = {"firefighter": firefighters}

    with open('Firefighter.json', 'w') as json_file:
        json.dump(data, json_file, indent=4)

    return [firefighter['position'] for firefighter in firefighters]

# Initialize with random positions
current_positions = generate_random_positions(6)

while True:
    # Update positions based on the last known positions
    current_positions = generate_random_positions(6, initial_positions=current_positions)
    print("Updated positions")
    time.sleep(2)  # Wait for 2 seconds
