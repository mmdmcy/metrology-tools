from flask import Flask, request, jsonify

app = Flask(__name__)

# Sample data structure to hold Program Increment data
program_increments = []

@app.route('/api/planner/import', methods=['POST'])
def import_data():
    data = request.json
    # Logic to import data goes here
    program_increments.append(data)
    return jsonify({"message": "Data imported successfully"}), 201

@app.route('/api/planner/sync', methods=['POST'])
def sync_with_jira():
    # Logic to synchronize with JIRA Align goes here
    return jsonify({"message": "Synchronization with JIRA Align successful"}), 200

@app.route('/api/planner/data', methods=['GET'])
def get_data():
    return jsonify(program_increments), 200

if __name__ == '__main__':
    app.run(debug=True)